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
    public class CtrlInvoice : DbTableController<Invoice>
    {
        public override bool IsRecordExists(Invoice record)
        {
            throw new NotImplementedException();
        }

        /// <summary>Throws is connection failed</summary>
        /// <exception cref="MySqlException"></exception>
        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetInvoices`()";
            MySqlDataReader DbReader = Command.ExecuteReader();

            Invoice tempInvoice;
            List<KeyValuePair<TableRecordKey, bool>> mapSuccess = new();
            lock (Collection.InvoiceDataStore)
            {
                Invoices.Clear();
                Customer? referencedCustomer = null;
                while (DbReader.Read())
                {
                    tempInvoice = new Invoice();
                    tempInvoice.Key = new TableRecordKey((int)DbReader[0]);
                    if (DbReader[1] is not DBNull)
                    {
                        referencedCustomer = Customers.First(current => current.KeyIsSame((int)DbReader[1]));
                        tempInvoice.Customer = referencedCustomer;
                    }
                    tempInvoice.BaseCurrency = DbReader[2].ToString();
                    bool result = Invoices.Add(tempInvoice);
                    mapSuccess.Add(new KeyValuePair<TableRecordKey, bool>(tempInvoice.TableKey, result));
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

        public override bool IsRecordChanged(Invoice record)
        {
            _ = base.IsRecordChanged(record); // Good, if not thrown.

            Invoice invoiceOroginal = Invoices.First(current => current.KeyIsSame(record));
            return invoiceOroginal != record;
        }

        public override bool SaveRecord(Invoice record)
        {
            base.SaveRecord(record);

            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = $"CALL `ModifyInvoice`({record.TableKey.Id}, {record.Customer.Key}, {record.BaseCurrency});";
            int rowsAffected = Command.ExecuteNonQuery();

            if (rowsAffected == 1)
                return true;

            if (rowsAffected == 0)
                return false;

            ErrorHandler.ErrorMessage = "Túl sok adat mentődött";
            ErrorHandler.Exception = new Exception($"More than 1 rows affected in {nameof(CtrlCustomer)}.{nameof(SaveRecord)}");
            ErrorHandler.ErrorCode = ErrorHandler.Code.SavingError;

            return false;
        }
    }
}
