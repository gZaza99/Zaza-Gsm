using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;
using ZazaGsm.View;
using ZazaGsm.Base;

namespace ZazaGsm.Controller
{
    public class CtrlInvoiceItem : DbTableController<InvoiceItem>
    {
        public override bool IsRecordExists(InvoiceItem record)
        {
            throw new NotImplementedException();
        }
        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetInvoiceItems`(NULL)";
            MySqlDataReader DbReader = Command.ExecuteReader();

            Invoice? tempInvoice;
            Issue? tempIssue;
            InvoiceItem tempInvoiceItem;
            List<KeyValuePair<TableRecordKey, bool>> mapSuccess = new();
            lock (Collection.InvoiceItemDataStore)
            {
                Customers.Clear();
                int? issueId;
                bool result;
                while (DbReader.Read())
                {
                    tempInvoiceItem = new InvoiceItem();
                    tempInvoiceItem.Key = new TableRecordKey((int)DbReader[0]);
                    tempInvoiceItem.Remarks = DbReader[1].ToString();
                    tempInvoiceItem.Sum = (int)DbReader[2];
                    tempInvoiceItem.Currency = (string)DbReader[3];
                    tempInvoice = Invoices.First(current => current.KeyIsSame((int)DbReader[4]));
                    issueId = (DbReader[5] is not DBNull) ? issueId = (int)DbReader[5] : null;
                    tempIssue = (issueId != null) ? Issues.FirstOrDefault(current => current.KeyIsSame((int)issueId)) : null;
                    tempInvoiceItem.ItemsStatus = (InvoiceStatus)((sbyte)DbReader[6] - 1);
                    tempInvoiceItem.IsPurchase = Convert.ToBoolean(DbReader[7]);
                    tempInvoiceItem.PaymentDate = (DbReader[8] is DBNull) ? null : DateTime.Parse(DbReader[8].ToString());
                    if (tempInvoice != null)
                    {
                        tempInvoiceItem.Invoice = tempInvoice;
                        tempInvoice.Items.Add(tempInvoiceItem);
                    }
                    if (tempIssue != null)
                    {
                        tempInvoiceItem.Issue = tempIssue;
                        if (tempInvoiceItem.IsPurchase == false && tempInvoiceItem.ItemsStatus == InvoiceStatus.Lezárt)
                            tempIssue.IsPayed = true;
                    }

                    result = InvoiceItems.Add(tempInvoiceItem);
                    mapSuccess.Add(new KeyValuePair<TableRecordKey, bool>(tempInvoiceItem.TableKey, result));
                }

                Task.Run(async () =>
                {
                    DbReader.Close();
                    DbConnection.Close();
                    await DbReader.DisposeAsync();
                    DbConnection.Dispose();
                    DbConnection = null;
                });
            }
        }
    }
}
