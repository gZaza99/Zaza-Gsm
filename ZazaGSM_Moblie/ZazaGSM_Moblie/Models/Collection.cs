using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using MySqlConnector;
using System.Data.Common;
using System.Threading.Tasks;
using ZazaGsm.Base;

namespace ZazaGSM_Moblie.Models
{
    public static class Collection
    {
        public static ObservableCollection<Device> Devices { get; } = new ObservableCollection<Device>();
        public static ObservableCollection<Issue> Issues { get; } = new ObservableCollection<Issue>();
        public static ObservableCollection<Invoice> Invoices { get; } = new ObservableCollection<Invoice>();
        public static ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        public static void LoadDevices()
        {
#if DEBUG
            string ConnStr = App.AppSettings.ConnectionString;
            MySqlConnection DbConnection = new MySqlConnection(ConnStr);
#else
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
#endif
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "SELECT * FROM `Device_tbl`;";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Devices)
            {
                Devices.Clear();
                Device tempDevice;
                DeviceImage deviceImage;
                while (DbReader.Read())
                {
                    if (DbReader[6] == DBNull.Value)
                        tempDevice = new Device(Convert.ToInt32(DbReader[0]));
                    else
                        tempDevice = new Device(Convert.ToInt32(DbReader[0]), (string)DbReader[6]);

                    tempDevice.Type = (string)DbReader[1];
                    Devices.Add(tempDevice);
                }

                DbReader.Close();
                DbConnection.Close();
                DbConnection.Dispose();
            }
        }

        public static bool SaveDevice(Device newDevice)
        {
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = $"CALL `SaveDevice`(NULL, '{newDevice.Type}', NULL, NULL, NULL);";
            int rowsAffected = Command.ExecuteNonQuery();

            DbConnection.Close();
            DbConnection.Dispose();

            if (rowsAffected == 1)
            {
                Devices.Clear();
                _ = System.Threading.Tasks.Task.Run(LoadDevices);
                return true;
            }

            return false;
        }

        public static void LoadIssues()
        {
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "SELECT * FROM `Issue_tbl`;";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Issues)
            {
                Issues.Clear();
                Issue tempIssue;
                while (DbReader.Read())
                {
                    tempIssue = new Issue();
                    tempIssue.TableKey = new TableRecordKey((int)DbReader[0]);
                    tempIssue.Complaint = (string)DbReader[1];
                    tempIssue.IsAccepted = Convert.ToBoolean(DbReader[2]);
                    tempIssue.Opinion = (DbReader[3] is DBNull) ? string.Empty : (string)DbReader[3];
                    tempIssue.Quotation = (DbReader[4] is DBNull) ? (int?)null : Convert.ToInt32(DbReader[4]);
                    tempIssue.Currency = (DbReader[5] is DBNull) ? string.Empty : (string)DbReader[5];
                    tempIssue.StatusReason = (DbReader[6] is DBNull) ? string.Empty : (string)DbReader[6];
                    tempIssue.Device = Devices.First(device => device.KeyIsSame((int)DbReader[7]));
                    tempIssue.Status = (IssueStatus)Enum.ToObject(typeof(IssueStatus), (int)DbReader[8] - 1);
                    Issues.Add(tempIssue);
                }
                DbReader.Close();
                DbConnection.Close();
                DbConnection.Dispose();
                DbConnection = null;
            }
        }

        public static bool SaveIssue(Issue issue)
        {
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `SaveIssue`(";
            Command.CommandText += issue.TableKey.ToString();
            Command.CommandText += ", '" + issue.Complaint + "'";
            Command.CommandText += ", " + (issue.IsAccepted ? "TRUE" : "FALSE");
            Command.CommandText += ", " + (string.IsNullOrEmpty(issue.Opinion) ? "NULL" : "'" + issue.Opinion + "'");
            Command.CommandText += ", " + (issue.Quotation is null ? "null" : issue.Quotation.ToString());
            Command.CommandText += ", " + (string.IsNullOrEmpty(issue.Currency) ? "NULL" : "'" + issue.Currency + "'");
            Command.CommandText += ", " + (string.IsNullOrEmpty(issue.StatusReason) ? "NULL" : "'" + issue.StatusReason + "'");
            Command.CommandText += ", " + issue.Device.TableKey.ToString();
            Command.CommandText += ", " + (((int)issue.Status) + 1);
            Command.CommandText += ");";
            
            int rowsAffected = Command.ExecuteNonQuery();

            DbConnection.Close();
            DbConnection.Dispose();

            if (rowsAffected == 1)
            {
                Devices.Clear();
                _ = System.Threading.Tasks.Task.Run(LoadIssues);
                return true;
            }

            return false;
        }

        public static void LoadInvoices()
        {
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "SELECT * FROM `Invoice_tbl`;";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Invoices)
            {
                Invoices.Clear();
                Invoice tempInvoice;
                while (DbReader.Read())
                {
                    tempInvoice = new Invoice();
                    tempInvoice.TableKey = new TableRecordKey((int)DbReader[0]);
                    tempInvoice.BaseCurrency = (string)DbReader[2];
                    tempInvoice.Customer = Customers.First(currentCustomer => currentCustomer.KeyIsSame((int)DbReader[3]));
                    Invoices.Add(tempInvoice);
                }
                DbReader.Close();
                DbConnection.Close();
                DbConnection.Dispose();
                DbConnection = null;
            }
        }

        public static bool AddInvoice(Customer customer)
        {
            if (customer is null)
                return false;

            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `AddInvoice`(";
            Command.CommandText += customer.TableKey.ToString();
            Command.CommandText += ");";

            int rowsAffected = Command.ExecuteNonQuery();

            DbConnection.Close();
            DbConnection.Dispose();

            if (rowsAffected == 1)
            {
                Devices.Clear();
                _ = System.Threading.Tasks.Task.Run(LoadIssues);
                return true;
            }

            return false;
        }

        public static void LoadCustomers()
        {
            MySqlConnection DbConnection = new MySqlConnection(App.AppSettings.ConnectionString);
            if (DbConnection.State != System.Data.ConnectionState.Closed)
                DbConnection.Close();
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "SELECT * FROM `customers`;";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Customers)
            {
                Customers.Clear();
                Customer tempInvoice;
                while (DbReader.Read())
                {
                    tempInvoice = new Customer();
                    tempInvoice.TableKey = new TableRecordKey((int)DbReader[0]);
                    tempInvoice.Name = (string)DbReader[1];
                    Customers.Add(tempInvoice);
                }
                DbReader.Close();
                DbConnection.Close();
                DbConnection.Dispose();
                DbConnection = null;
            }
        }
    }
}
