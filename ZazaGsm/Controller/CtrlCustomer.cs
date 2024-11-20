using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;
using MySqlConnector;
using System.Diagnostics;
using ZazaGsm.View;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ZazaGsm.Controller
{
    public class CtrlCustomer : DbTableController<Customer>
    {
        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetCustomers`()";
            MySqlDataReader DbReader = Command.ExecuteReader();

            Customer tempCustomer;
            List<KeyValuePair<TableRecordKey, bool>> mapSuccess = new();
            lock (Collection.CustomerDataStore)
            {
                Customers.Clear();
                while (DbReader.Read())
                {
                    tempCustomer = new Customer((int)DbReader[0]);
                    tempCustomer.Name = (string)DbReader[1];
                    bool result = Customers.Add(tempCustomer);
                    mapSuccess.Add(new KeyValuePair<TableRecordKey, bool>(tempCustomer.TableKey, result));
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

        public override bool IsRecordChanged(Customer customer)
        {
            _ = base.IsRecordChanged(customer);

            return Collection.CustomerDataStore.First(current => current.KeyIsSame(customer)) != default(Customer);
        }

        public override bool SaveRecord(Customer record)
        {
            base.SaveRecord(record);

            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();
            
            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = $"CALL `SaveCustomer`({record.TableKey.Id}, {record.Name});";
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

        public override bool IsRecordExists(Customer record)
            => Collection.CustomerDataStore.First(current => current.Key == record.Key) != default(Customer);
    }
}
