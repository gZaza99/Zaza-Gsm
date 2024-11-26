using System.Collections.ObjectModel;
using System.Diagnostics;
using ZazaGsm.Controller;
using ZazaGsm.Model;
using ZazaGsm.Base;

namespace ZazaGsm.View
{
    public partial class IssuesView : UserControl, IResizable
    {
        public delegate void ShowMessageEventHandler(string message, bool IsError);
        public event ShowMessageEventHandler? ShowMessage;
        public CtrlIssue Controller { get; set; }
        private CtrlCustomer2Device CtrlCustomerDevice;
        private Issue? _selectedIssue;
        private Issue? SelectedIssue
        {
            get => _selectedIssue;
            set
            {
                _selectedIssue = value;
                OnIssueSelected();
            }
        }

        public IssuesView()
        {
            InitializeComponent();
            Controller = new CtrlIssue();
            CtrlCustomerDevice = new CtrlCustomer2Device();
            FilterView.SetProperties(new string[11] { "Id", "Eszköz", "Panasz", "Vélemény", "Elfogadva", "Fizetve", "Státus", "Státus oka", "Ajánlat", "Valuta", "Ügyfél" });
            FilterView.Ready += OnReadyToFilter;
        }

        private void OnReadyToFilter(object? sender, EventArgs e)
        {
            FilterEventArgs<Issue> args;
            if (sender.GetType() == typeof(FilterView1))
            {
                FilterView1 Sender = (FilterView1)sender;
                args = new FilterEventArgs<Issue>(Collection.TaskDataStore.GetAll(), Sender.SelectedProperty, (Relation)Sender.SelectedRelationIndex, Sender.Value, Sender.Negate);
            }
            else //if (sender.GetType() == typeof(FilterView2))
            {
                FilterView2 Sender = (FilterView2)sender;
                args = new FilterEventArgs<Issue>(Collection.TaskDataStore.GetAll(), Sender.SelectedProperty, (Relation)Sender.SelectedRelationIndex, Sender.Value, Sender.Negate);
            }

            Controller.FilterOn(sender, args);
        }

        public void OnFiltering(object? sender, EventArgs e)
        {
            if (FilterView.SelectedRelationIndex == -1 ||
                FilterView.SelectedPropertyIndex == -1 ||
                string.IsNullOrEmpty(FilterView.Value))
                return;

            string eq = FilterView.Negate ? " not" : string.Empty;
            Debug.WriteLine($"{FilterView.SelectedProperty}{eq} {FilterView.SelectedRelation} {FilterView.Value}");

            FilterEventArgs<Issue> args = new FilterEventArgs<Issue>(
                Collection.TaskDataStore.GetAll(),
                FilterView.SelectedProperty,
                FilterView.SelectedRelation,
                FilterView.Value,
                FilterView.Negate
            );
            ObservableCollection<Issue>? filteredList = Controller.FilterOn(this, args);
            if (filteredList == null)
                Debug.WriteLine($"{nameof(CtrlIssue)}.{nameof(CtrlIssue.FilterOn)}({FilterView.SelectedProperty}, {FilterView.Value}, {FilterView.Negate}) returned with NULL value.");
        }

        public void Clear()
        {
            if (Grid.InvokeRequired)
            {
                Grid.Invoke(Clear);
                return;
            }
            Grid.Rows.Clear();
            SelectedIssue = null;
        }

        public void AddIssues(BaseDataStore<Issue> issuesToAdd)
        {
            Issue currentIssue;
            DataGridViewRow row;
            DataGridViewComboBoxCell cellDevice;
            DataGridViewTextBoxCell cellComplaint;
            DataGridViewCheckBoxCell cellAccepted;
            DataGridViewComboBoxCell cellStatus;
            DataGridViewTextBoxCell cellStatusReason;
            for (int i = 0; i < issuesToAdd.Count; i++)
            {
                currentIssue = issuesToAdd[i];
                row = new DataGridViewRow();
                row.HeaderCell.Value = currentIssue.TableKey.Id?.ToString();

                cellDevice = new DataGridViewComboBoxCell();
                for (int j = 0; j < Collection.DeviceDataStore.Count; j++)
                    cellDevice.Items.Add($"({Collection.DeviceDataStore[j].TableKey.Id}) {Collection.DeviceDataStore[j].Type}");
                cellDevice.Value = $"({currentIssue.Device.TableKey.Id}) {currentIssue.Device.Type}";
                row.Cells.Add(cellDevice);

                cellComplaint = new DataGridViewTextBoxCell();
                cellComplaint.Value = currentIssue.Complaint?.ToString();
                row.Cells.Add(cellComplaint);

                cellAccepted = new DataGridViewCheckBoxCell();
                cellAccepted.Value = currentIssue.IsAccepted;
                row.Cells.Add(cellAccepted);

                cellStatus = new DataGridViewComboBoxCell();
                cellStatus.DataSource = Enum.GetValues(typeof(IssueStatus));
                cellStatus.ValueType = typeof(IssueStatus);
                cellStatus.Value = currentIssue.Status;
                row.Cells.Add(cellStatus);

                cellStatusReason = new DataGridViewTextBoxCell();
                cellStatusReason.Value = currentIssue.StatusReason;
                row.Cells.Add(cellStatusReason);

                Grid.Invoke(() => Grid.Rows.Add(row));
            }
        }

        public void TryRefresh(bool forceRefresh = true)
        {
            if (forceRefresh)
                CtrlCustomerDevice.LoadData();
            Controller.LoadData();
            Clear();
            AddIssues(Collection.TaskDataStore);
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            FilterView.OnResize(e);

            TxtbQuotation.Location = new Point(PanelDetails.ClientSize.Width - TxtbQuotation.Size.Width - 5, TxtbQuotation.Location.Y);
            TxtbQuoCurrency.Location = new Point(PanelDetails.ClientSize.Width - TxtbQuoCurrency.Size.Width - 5, TxtbQuoCurrency.Location.Y);
            CheckPayed.Location = new Point(PanelDetails.ClientSize.Width - 179 - CheckPayed.Size.Width, CheckPayed.Location.Y);
            TxtbCustomer.Location = new Point(PanelDetails.ClientSize.Width - TxtbCustomer.Size.Width - 5, TxtbCustomer.Location.Y);
            DtpClosing.Location = new Point(PanelDetails.ClientSize.Width - DtpClosing.Size.Width - 5, DtpClosing.Location.Y);

            LblQuotation.Location = new Point(PanelDetails.ClientSize.Width - 2 * 5 - TxtbQuotation.Size.Width - LblQuotation.Size.Width, LblQuotation.Location.Y);
            LblQuoCurrency.Location = new Point(PanelDetails.ClientSize.Width - 2 * 5 - TxtbQuoCurrency.Size.Width - LblQuoCurrency.Size.Width, LblQuoCurrency.Location.Y);
            LblCustomer.Location = new Point(PanelDetails.ClientSize.Width - 2 * 5 - TxtbCustomer.Size.Width - LblCustomer.Size.Width, LblCustomer.Location.Y);
            LblClosing.Location = new Point(PanelDetails.ClientSize.Width - 2 * 5 - DtpClosing.Size.Width - LblClosing.Size.Width, LblClosing.Location.Y);

            int threshold = LblQuotation.Location.X - 5;
            TxtbComplaint.Size = new Size(threshold / 2 - 10, TxtbComplaint.Size.Height);
            TxtbOpinion.Size = new Size(threshold / 2 - 10, TxtbOpinion.Size.Height);
            TxtbOpinion.Location = new Point(threshold / 2, TxtbOpinion.Location.Y);
            LblOpinion.Location = new Point(threshold / 2, LblOpinion.Location.Y);
            return Task.CompletedTask;
        }

        private void OnIssueSelected()
        {
            if (SelectedIssue == null)
            {
                TxtbComplaint.Text = string.Empty;
                TxtbOpinion.Text = string.Empty;
                TxtbQuotation.Text = string.Empty;
                TxtbQuoCurrency.Text = string.Empty;
                CheckPayed.Checked = false;
                TxtbCustomer.Text = string.Empty;
            }
            else
            {
                TxtbComplaint.Text = SelectedIssue.Complaint ?? string.Empty;
                TxtbOpinion.Text = SelectedIssue.Opinion ?? string.Empty;
                TxtbQuotation.Text = SelectedIssue.Quotation.ToString();
                TxtbQuoCurrency.Text = SelectedIssue.Currency.ToString();
                CheckPayed.Checked = SelectedIssue.IsPayed;
                TxtbCustomer.Text = SelectedIssue.Device?.Customer2Device?.Customer.Name ?? string.Empty;
            }
        }

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) // Legfelső sor
                return;
            if (Grid.Rows[e.RowIndex].HeaderCell.Value is null) // Legalsó sor
                return;
            int Id = Convert.ToInt32(Grid.Rows[e.RowIndex].HeaderCell.Value);
            SelectedIssue = Collection.TaskDataStore.First(issue => issue.KeyIsSame(Id));
        }

        private void Grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) // Legfelső sor
                return;
            if (SelectedIssue is null)
                return;
            Issue newIssue = new();
            if (Grid.Rows[e.RowIndex].HeaderCell.Value is null) // Legalsó sor
                return;
            newIssue.TableKey = new TableRecordKey(Convert.ToInt32(Grid.Rows[e.RowIndex].HeaderCell.Value));
            if (string.IsNullOrEmpty(TxtbComplaint.Text))
            {
                ErrorHandler.ErrorMessage = "A `Complaint` mező nem lehet üres";
                ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;
                return;
            }
            newIssue.Complaint = TxtbComplaint.Text;
            newIssue.IsAccepted = Convert.ToBoolean(Grid[2, e.RowIndex].EditedFormattedValue);
            var cell = (DataGridViewComboBoxCell)Grid[3, e.RowIndex];
            newIssue.Status = Enum.Parse<IssueStatus>(cell.EditedFormattedValue.ToString());
            newIssue.StatusReason = (Grid[4, e.RowIndex].EditedFormattedValue is null) ? string.Empty : (string)Grid[4, e.RowIndex].EditedFormattedValue;
            newIssue.Opinion = TxtbOpinion.Text;
            if (!string.IsNullOrEmpty(TxtbQuotation.Text))
            {
                try { newIssue.Quotation = Convert.ToInt32(TxtbQuotation.Text); }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage = "Csak egész szám adható meg a 'Quotation' mezőben!\n" + ex.Message;
                    ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;
                    return;
                }
            }
            else
            if (!string.IsNullOrEmpty(TxtbQuoCurrency.Text) && TxtbQuoCurrency.Text.Length != 3)
            {
                ErrorHandler.ErrorMessage = "Csak 3 betűs valuta-rövidítés adható meg a 'Currency' mezőven.";
                ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;
                return;
            }
            newIssue.Currency = TxtbQuoCurrency.Text;
            string text = (string)Grid[0, e.RowIndex].EditedFormattedValue;
            int id = Convert.ToInt32(text.Substring(1, text.IndexOf(')') - 1));
            newIssue.Device = Collection.DeviceDataStore.First(current => current.KeyIsSame(id));
            if (!Controller.IsRecordChanged(newIssue))
                return;

            if (Controller.SaveRecord(newIssue) == false)
            {
                if (string.IsNullOrEmpty(ErrorHandler.ErrorMessage))
                    ErrorHandler.ErrorMessage = "Nem sikerült a mentés";
                else
                    ErrorHandler.ErrorMessage += "\nNem sikerült a mentés";
                ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;
            }
        }

        private void InpControl_Leave(object sender, EventArgs e)
        {
            var args = new DataGridViewCellEventArgs(
                Grid.CurrentCell.ColumnIndex,
                Grid.CurrentCell.RowIndex);
            Grid_RowLeave(this, args);
        }

        private void Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Debug.WriteLine($"{sender.GetType()} - {e.RowIndex}");
        }

        private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Debug.WriteLine($"{sender.GetType()} - {e.RowIndex};{e.ColumnIndex};{e.Cancel}");
        }
    }
}
