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
    public class CtrlDevice : DbTableController<Device>
    {
        public override bool IsRecordExists(Device record)
            => Devices.First(current => current.TableKey == record.TableKey) != default(Device);

        public override void LoadData()
        {
            DbConnection = new MySqlConnection(ZazaGSMForm.AppSettings.ConnectionString);
            DbConnection.Open();

            MySqlCommand Command = DbConnection.CreateCommand();
            Command.CommandText = "CALL `GetDevices`(NULL);";
            MySqlDataReader DbReader = Command.ExecuteReader();

            lock (Collection.DeviceDataStore)
            {
                Devices.Clear();
                Device tempDevice;
                while (DbReader.Read())
                {
                    tempDevice = new Device((int)DbReader[0]);
                    tempDevice.Type = (string)DbReader[1];
                    tempDevice.Barcode = (DbReader[2] == DBNull.Value) ? string.Empty : DbReader[2].ToString();
                    _ = Devices.Add(tempDevice);
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
