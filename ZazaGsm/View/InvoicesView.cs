using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZazaGsm.Controller;
using ZazaGsm.Model;

namespace ZazaGsm.View
{
    public partial class InvoicesView : UserControl, IResizable
    {
        public CtrlInvoice ControllerInv { get; set; }
        public CtrlInvoiceItem ControllerInvItem { get; set; }
        private DataGridViewRow recoveryData;

        public InvoicesView()
        {
            InitializeComponent();
            ControllerInv = new CtrlInvoice();
            ControllerInvItem = new CtrlInvoiceItem();
            FilterView.SetProperties(new string[11] { "Számla ID", "Végösszeg", "Ügyfél név", "Ügyfél ID", "Számla státusz", "Számla tétel ID", "Összeg", "Valuta", "Leíárs", "Státusz", "Feladat ID (FID)" });
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            FilterView.OnResize(e);

            return Task.CompletedTask;
        }

        public void Clear()
        {
            GridInvoices.Invoke(GridInvoices.Rows.Clear);
            GridInvoiceItems.Invoke(GridInvoiceItems.Rows.Clear);
        }

        public void AddInvoices(List<Invoice> invoices)
        {
            Invoice tempInvoice;
            DataGridViewRow row;
            DataGridViewTextBoxCell cellCustomerName;
            DataGridViewTextBoxCell cellCustomerId;
            DataGridViewTextBoxCell cellTotalSum;
            DataGridViewTextBoxCell cellCurrency;
            DataGridViewComboBoxCell cellHeadStatus;
            for (int index = 0; index < invoices.Count; index++)
            {
                tempInvoice = invoices[index];
                row = new DataGridViewRow();
                row.HeaderCell.Value = tempInvoice.TableKey.Id.ToString();

                cellTotalSum = new DataGridViewTextBoxCell();
                cellTotalSum.Value = tempInvoice.TotalSum.ToString();
                row.Cells.Add(cellTotalSum);

                cellCurrency = new DataGridViewTextBoxCell();
                cellCurrency.Value = tempInvoice.BaseCurrency;
                row.Cells.Add(cellCurrency);

                cellCustomerName = new DataGridViewTextBoxCell();
                cellCustomerId = new DataGridViewTextBoxCell();
                if (tempInvoice.Customer is null)
                {
                    cellCustomerName.Value = "Saját";
                    cellCustomerId.Value = "0";
                }
                else
                {
                    cellCustomerName.Value = tempInvoice.Customer.Name;
                    cellCustomerId.Value = tempInvoice.Customer.TableKey.Id;
                }
                row.Cells.Add(cellCustomerName);
                row.Cells.Add(cellCustomerId);

                cellHeadStatus = new DataGridViewComboBoxCell();
                cellHeadStatus.Items.AddRange(
                    InvoiceStatus.Új.ToString(),
                    InvoiceStatus.Nyitott.ToString(),
                    InvoiceStatus.Lezárt.ToString()
                );
                cellHeadStatus.Value = tempInvoice.Status.ToString();
                row.Cells.Add(cellHeadStatus);

                GridInvoices.Invoke(() => GridInvoices.Rows.Add(row));
            }
        }

        public void AddInvoiceItems(List<InvoiceItem> invoiceItems)
        {
            InvoiceItem tempInvoiceItem;
            DataGridViewRow row;
            //összeg, valuta, leírás, sztornó, státus, FID
            DataGridViewTextBoxCell cellSum;
            DataGridViewTextBoxCell cellCurrency;
            DataGridViewTextBoxCell cellRemarks;
            DataGridViewComboBoxCell cellStatus;
            DataGridViewTextBoxCell cellIssueId;
            for (int index = 0; index < invoiceItems.Count; index++)
            {
                tempInvoiceItem = invoiceItems[index];
                row = new DataGridViewRow();
                row.HeaderCell.Value = tempInvoiceItem.TableKey.Id.ToString();

                cellSum = new DataGridViewTextBoxCell();
                cellSum.Value = tempInvoiceItem.Sum;
                row.Cells.Add(cellSum);

                cellCurrency = new DataGridViewTextBoxCell();
                cellCurrency.Value = tempInvoiceItem.Currency;
                row.Cells.Add(cellCurrency);

                cellRemarks = new DataGridViewTextBoxCell();
                cellRemarks.Value = tempInvoiceItem.Remarks;
                row.Cells.Add(cellRemarks);

                cellStatus = new DataGridViewComboBoxCell();
                cellStatus.Items.AddRange(
                    InvoiceStatus.Új.ToString(),
                    InvoiceStatus.Nyitott.ToString(),
                    InvoiceStatus.Lezárt.ToString()
                );
                cellStatus.Value = tempInvoiceItem.ItemsStatus.ToString();
                row.Cells.Add(cellStatus);

                cellIssueId = new DataGridViewTextBoxCell();
                if (tempInvoiceItem.Issue != null)
                    cellIssueId.Value = tempInvoiceItem.Issue.TableKey.Id.ToString();
                row.Cells.Add(cellIssueId);

                GridInvoiceItems.Invoke(() => GridInvoiceItems.Rows.Add(row));
            }
        }

        public void TryRefresh()
        {
            ControllerInv.LoadData();
            ControllerInvItem.LoadData();
            Clear();
            AddInvoices(Collection.InvoiceDataStore.GetAll());
        }

        private void GridInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (GridInvoices.Rows[e.RowIndex].HeaderCell.Value is null)
                return;
            recoveryData = GridInvoices.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GridInvoices.Rows[e.RowIndex].HeaderCell.Value);
            Invoice containerInvoice = Collection.InvoiceDataStore.First(current => current.KeyIsSame(Id));
            if (containerInvoice == null)
                return;
            if (GridInvoiceItems.InvokeRequired)
                GridInvoiceItems.Invoke(GridInvoiceItems.Rows.Clear);
            else
                GridInvoiceItems.Rows.Clear();
            AddInvoiceItems(containerInvoice.Items);
        }

        private void GridInvoices_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex <= 0 || e.ColumnIndex <= 0) // Not headrow or headcolumn
                return;
            if (GridInvoices.Rows[e.RowIndex].HeaderCell.Value == null) // No Id
                return;

            bool needsRecovery = false;
            int id = Convert.ToInt32(GridInvoices.Rows[e.RowIndex].HeaderCell.Value);
            Invoice changingInvoice = new(id);
            if (GridInvoices[1, e.RowIndex].Value == null)
                changingInvoice.Currency = null;
            else if (GridInvoices[1, e.RowIndex].Value.ToString().Length != 3)
            {
                ErrorHandler.ErrorMessage = "A valuta pontosan 3 betűs.";
                ErrorHandler.ErrorCode = ErrorHandler.Code.InvalidData;
            }
            else
                changingInvoice.Currency = GridInvoices[1, e.RowIndex].Value.ToString();
            if (GridInvoices[3, e.RowIndex].Value == null)
            {
                ErrorHandler.ErrorMessage = "Az ügyfél azonosító kötelezően kitöltendő.";
                ErrorHandler.ErrorCode = ErrorHandler.Code.InvalidData;
                if (GridInvoices.InvokeRequired)
                {

                }
                else
                {
                    GridInvoices[]
                }
                return;
            }
            int customerId = Convert.ToInt32(GridInvoices[3, e.RowIndex].Value);
            Customer? tempCustomer = Collection.CustomerDataStore.FirstOrDefault(customer => customer.KeyIsSame(customerId));
            if (tempCustomer == null)
            {
                ErrorHandler.ErrorMessage = "Nem létezik ügyfél a megadott azonosítóval.";
                ErrorHandler.ErrorCode = ErrorHandler.Code.DataNotFound;
                if (GridInvoices.InvokeRequired)
                    GridInvoices.Invoke(() =>
                    {
                        GridInvoices[e.ColumnIndex, e.RowIndex].Value = recoveryData;
                    });
                else
                    GridInvoices[e.ColumnIndex, e.RowIndex].Value = recoveryData;
                return;
            }
            else
                changingInvoice.Customer = tempCustomer;

            if (recoveryData != null && GridInvoices[e.ColumnIndex, e.RowIndex].Value != recoveryData)
            {
                try
                {
                    ControllerInv.SaveRecord(changingInvoice);
                }
                catch (MySqlException ex)
                {
                    ErrorHandler.ErrorMessage = "Nem sikerült elmenteni a számlát";
                    ErrorHandler.Exception = ex;
                    ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;
                }
            }*/
        }
    }
}