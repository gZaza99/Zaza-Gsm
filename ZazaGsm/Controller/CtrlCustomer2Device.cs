using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;
using ZazaGsm.View;

namespace ZazaGsm.Controller
{
    public class CtrlCustomer2Device : DbRelationController<Customer2Device>
    {
        public override bool IsRecordExists(Customer2Device record)
            => CustomerDeviceRelations.First(current => current.Key == record.Key) != default(Customer2Device);

        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetCustomer2Device`();";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Collection.Customer2DeviceDataStore)
            {
                CustomerDeviceRelations.Clear();
                Customer2Device tempCustomer2Device;
                while (DbReader.Read())
                {
                    tempCustomer2Device = new Customer2Device()
                    {
                        RelationKey = new RelationRecordKey(Convert.ToInt32(DbReader[0]), Convert.ToInt32(DbReader[1]))
                    };

                    tempCustomer2Device.Customer = Customers.First(current => current.TableKey.Id == tempCustomer2Device.RelationKey.IdLeft);
                    tempCustomer2Device.Customer.Customer2Device = tempCustomer2Device;
            
                    tempCustomer2Device.Device = Devices.First(current => current.TableKey.Id == tempCustomer2Device.RelationKey.IdRight);
                    tempCustomer2Device.Device.Customer2Device = tempCustomer2Device;

                    _ = CustomerDeviceRelations.Add(tempCustomer2Device);
                }
                Task.Run(() =>
                {
                    DbReader.Close();
                    DbConnection.Close();
                    DbConnection.Dispose();
                    DbConnection = null;
                });
            }
        }
    }
}
