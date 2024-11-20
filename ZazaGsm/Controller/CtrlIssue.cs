using MySqlConnector;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;
using ZazaGsm.View;

namespace ZazaGsm.Controller
{
    public class CtrlIssue : DbTableController<Issue>
    {
        public override bool IsRecordExists(Issue record)
            => Collection.TaskDataStore.FirstOrDefault(current => current.Key == record.Key) != default(Issue);

        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetIssues`(NULL);";
            DbDataReader = Command.ExecuteReader();

            lock (Collection.TaskDataStore)
            {
                Issues.Clear();
                Issue tempIssue;
                while (DbDataReader.Read())
                {
                    tempIssue = new Issue();
                    tempIssue.TableKey = new TableRecordKey((int)DbDataReader[0]);
                    tempIssue.Complaint = (string)DbDataReader[1];
                    tempIssue.Status = (IssueStatus)((sbyte)DbDataReader[2] - 1);
                    tempIssue.StatusReason = (DbDataReader[3] is DBNull) ? string.Empty : (string)DbDataReader[3];
                    tempIssue.IsAccepted = Convert.ToBoolean(DbDataReader[4]);
                    tempIssue.Opinion = (DbDataReader[5] is DBNull) ? string.Empty : (string)DbDataReader[5];
                    tempIssue.Quotation = (DbDataReader[6] is DBNull) ? null : (int)DbDataReader[6];
                    tempIssue.Device = Collection.DeviceDataStore.First(device => device.KeyIsSame((int)DbDataReader[7]));
                    tempIssue.AnnouncementDate = DateOnly.FromDateTime(DateTime.Parse(DbDataReader[8].ToString()));
                    tempIssue.ClosingDate = (DbDataReader[9] is DBNull) ? null : DateOnly.FromDateTime(DateTime.Parse((string)DbDataReader[9]));
                    _ = Issues.Add(tempIssue);
                }
                Task.Run(() =>
                {
                    DbDataReader.Close();
                    DbDataReader.Dispose();
                    DbConnection.Close();
                    DbConnection.Dispose();
                    DbConnection = null;
                });
            }
        }

        public override bool SaveRecord(Issue record)
        {
            base.SaveRecord(record);
            bool ToReturn;

            // 1. lépés: Lehérdezzük az adatbázisból az aktuális verziót.
            // 2. lépés: Megnézzük, mi változott
            // 3. lépés: HA az attribútumok (kivéve elsődleges kulcs) több, mint fele változott,
            //    AKKOR PUT eljárást hívunk
            //    KÜLÖNBEN egyesével PATCH eljárást hívunk

            // 1. lépés
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();
            Issue OriginalIssue;

            using (MySqlCommand Command = DbConnection.CreateCommand())
            {
                Command.CommandText = $"CALL `GetIssue`({record.Key.ToString()});";
                DbDataReader = Command.ExecuteReader();
                OriginalIssue = new Issue();

                if (DbDataReader.Read() == false)
                {
                    ErrorHandler.ErrorMessage = $"Nem létezik feladat a következő azonosítóval:" + record.Key.ToString();
                    return false;
                }
                OriginalIssue = new Issue();
                OriginalIssue.TableKey = new TableRecordKey((int)DbDataReader[0]);
                OriginalIssue.Complaint = (string)DbDataReader[1];
                OriginalIssue.Status = (IssueStatus)((sbyte)DbDataReader[2] - 1);
                OriginalIssue.StatusReason = (DbDataReader[3] is DBNull) ? string.Empty : (string)DbDataReader[3];
                OriginalIssue.IsAccepted = Convert.ToBoolean(DbDataReader[4]);
                OriginalIssue.Opinion = (DbDataReader[5] is DBNull) ? string.Empty : (string)DbDataReader[5];
                OriginalIssue.Quotation = (DbDataReader[6] is DBNull) ? null : (int)DbDataReader[6];
                OriginalIssue.Device = Collection.DeviceDataStore.First(device => device.KeyIsSame((int)DbDataReader[7]));
                OriginalIssue.AnnouncementDate = DateOnly.FromDateTime(DateTime.Parse(DbDataReader[8].ToString()));
                OriginalIssue.ClosingDate = (DbDataReader[9] is DBNull) ? null : DateOnly.FromDateTime(DateTime.Parse((string)DbDataReader[9]));
                DbDataReader.Close();
                _ = DbDataReader.DisposeAsync();
            }
            // 2. lépés
            List<string> ChangedProperties = new List<string>();
            if (OriginalIssue.Complaint != record.Complaint)
                ChangedProperties.Add(nameof(Issue.Complaint));
            if (OriginalIssue.Status != record.Status)
                ChangedProperties.Add(nameof(Issue.Status));
            if (OriginalIssue.StatusReason != record.StatusReason)
                ChangedProperties.Add(nameof(Issue.StatusReason));
            if (OriginalIssue.IsAccepted != record.IsAccepted)
                ChangedProperties.Add(nameof(Issue.IsAccepted));
            if (OriginalIssue.Opinion != record.Opinion)
                ChangedProperties.Add(nameof(Issue.Opinion));
            if (OriginalIssue.Quotation != record.Quotation)
                ChangedProperties.Add(nameof(Issue.Quotation));
            if (OriginalIssue.Device != record.Device)
                ChangedProperties.Add(nameof(Issue.Device));
            if (OriginalIssue.AnnouncementDate != record.AnnouncementDate)
                ChangedProperties.Add(nameof(Issue.AnnouncementDate));
            if (OriginalIssue.ClosingDate != record.ClosingDate)
                ChangedProperties.Add(nameof(Issue.ClosingDate));

            //3. lépés
            if (ChangedProperties.Count > 3)
            {
                using (MySqlCommand Command = DbConnection.CreateCommand())
                {
                    Command.CommandText = $"CALL `PutIssue`({record.Key.ToString()}, '{record.Complaint}', {(int)record.Status + 1}, '{record.StatusReason}', {record.IsAccepted}, '{record.Opinion}', '{record.Quotation}', {record.Device.Key.ToString()}, {record.AnnouncementDate}, {record.ClosingDate});";
                    DbDataReader = Command.ExecuteReader();
                    if (DbDataReader.Read() == false)
                        Debug.WriteLine("Server process not respond. Process: PutIssue");
                    if (Convert.ToByte(DbDataReader[0]) == 0)
                    {
                        Debug.WriteLine("Server process returned FALSE. Process: PutIssue");
                        ToReturn = false;
                    }
                    DbDataReader.Close();
                    _ = DbDataReader.DisposeAsync();
                }
            }
            else
            {
                List<bool> Check = new List<bool>();
                foreach (string prop in ChangedProperties)
                {
                    Check.Add(PatchIssue(record, prop));
                }
            }

            DbConnection.Close();
            DbConnection.Dispose();
            DbConnection = null;
            return true;
        }

        private bool PatchIssue(Issue issue, string property)
        {
            string ServerProperty = string.Empty;
            string ErrorMessage = "Nem sikerült menteni a";
            string? Param;
            switch (property)
            {
                case nameof(Issue.Complaint):
                    ErrorMessage += " panaszt";
                    Param = "'" + issue.Complaint + "'";
                    ServerProperty = property;
                    break;
                case nameof(Issue.Status):
                    ErrorMessage += " státuszt";
                    Param = ((int)issue.Status).ToString();
                    ServerProperty = property + "Code";
                    break;
                case nameof(Issue.StatusReason):
                    ErrorMessage += " státusz okát";
                    Param = "'" + issue.StatusReason + "'";
                    ServerProperty = property;
                    break;
                case nameof(Issue.IsAccepted):
                    ErrorMessage += "z elfogadottságot";
                    Param = issue.IsAccepted.ToString();
                    ServerProperty = property;
                    break;
                case nameof(Issue.Opinion):
                    ErrorMessage += " véleményt";
                    Param = "'" + issue.Opinion + "'";
                    ServerProperty = property;
                    break;
                case nameof(Issue.Quotation):
                    ErrorMessage += "z ajánlatot";
                    Param = issue.Quotation.ToString();
                    ServerProperty = property;
                    break;
                case nameof(Issue.Device):
                    ErrorMessage += " készüléket";
                    Param = issue.Device?.Key.ToString();
                    ServerProperty = property;
                    break;
                case nameof(Issue.AnnouncementDate):
                    ErrorMessage += " kiadás dátumát";
                    Param = "'" + issue.AnnouncementDate.ToString() + "'";
                    ServerProperty = property;
                    break;
                case nameof(Issue.ClosingDate):
                    ErrorMessage += " lezárás dátumát";
                    Param = "'" + issue.ClosingDate.ToString() + "'";
                    ServerProperty = property;
                    break;
                default:
                    Debug.WriteLine($"Unexpected property in {nameof(CtrlIssue)}.{nameof(PatchIssue)}: {property}");
                    Param = null;
                    break;
            }
            bool response;
            using (MySqlCommand Command = DbConnection.CreateCommand())
            {
                Command.CommandText = $"CALL `PatchIssue{ServerProperty}`({issue.Key.ToString()}, {Param});";
                DbDataReader = Command.ExecuteReader();
                if (DbDataReader.Read() == false)
                    Debug.WriteLine($"Server process not respond. Process: PatchIssue{property}");
                if (Convert.ToByte(DbDataReader[0]) == 0)
                {
                    ErrorHandler.ErrorMessage = ErrorMessage;
                    Debug.WriteLine($"Server process returned FALSE. Process: PatchIssue{property}");
                }
                else if (Convert.ToByte(DbDataReader[0]) != 1)
                    Debug.WriteLine($"Server process returned unexpected response: {DbDataReader[0]}. Process: PatchIssue{property}");
                response = Convert.ToBoolean(DbDataReader[0]);
                DbDataReader.Close();
                _ = DbDataReader.DisposeAsync();
            }
            return response;
        }

        public override bool IsRecordChanged(Issue record)
        {
            base.IsRecordChanged(record);
            if (record.TableKey.Id is null)
                return true;

            Issue? other = Issues.FirstOrDefault(current => current.KeyIsSame(record));
            bool justForDebug = other == record;
            return !justForDebug;
        }

        public ObservableCollection<Issue>? FilterOn(object sender, FilterEventArgs<Issue> e)
        {
            ObservableCollection<Issue>? filtered = base.Where(e.Property, e.Value, e.Negate);
            if (filtered != null)
                return filtered;
            if (e.Property == nameof(Issue.Complaint))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Complaint.ToLower() != e.Value.ToLower() : issue.Complaint.ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.Currency))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Currency != e.Value : issue.Currency == e.Value;
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.Device))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Device?.ToString().ToLower() != e.Value.ToLower() : issue.Device?.ToString().ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.IsAccepted))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.IsAccepted.ToString().ToLower() != e.Value.ToLower() : issue.IsAccepted.ToString().ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.IsPayed))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.IsPayed.ToString().ToLower() != e.Value.ToLower() : issue.IsPayed.ToString().ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.Opinion))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Opinion.ToLower() != e.Value.ToLower() : issue.Opinion.ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.Quotation))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Quotation != int.Parse(e.Value) : issue.Quotation == int.Parse(e.Value);
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.Status))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.Status.ToString().ToLower() != e.Value.ToLower() : issue.Status.ToString().ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            if (e.Property == nameof(Issue.StatusReason))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = e.Negate ? issue.StatusReason.ToLower() != e.Value.ToLower() : issue.StatusReason.ToLower() == e.Value.ToLower();
                    if (matches)
                        filtered.Add(issue);
                }
            }
            return filtered;
        }
    }
}
