using ZazaGsm.Model;
using MySqlConnector;
using ZazaGsm.Base;

namespace ZazaGsm.Controller
{
    public abstract class DatabaseController<T> : IDatabaseController<T> where T : IRecord
    {
        protected TableDataStore<Issue> Issues => Collection.TaskDataStore;
        protected TableDataStore<Device> Devices => Collection.DeviceDataStore;
        protected TableDataStore<Customer> Customers => Collection.CustomerDataStore;
        protected RelationDataStore<Customer2Device> CustomerDeviceRelations => Collection.Customer2DeviceDataStore;
        protected TableDataStore<Invoice> Invoices => Collection.InvoiceDataStore;
        protected TableDataStore<InvoiceItem> InvoiceItems => Collection.InvoiceItemDataStore;

        protected MySqlConnection? DbConnection { get; set; }
        protected MySqlDataReader? DbDataReader { get; set; }
        protected IRecord? RecordChanging;

        public virtual bool IsRecordChanged(T record)
        {
            if (record == null)
                throw new NullReferenceException($"{nameof(DatabaseController<T>)}.{nameof(IsRecordChanged)}.{nameof(record)} is null.");
            else
                return false;
        }
        public abstract bool IsRecordExists(T record);
        /// <summary>
        /// Loads the records from the database into the memory. Writes into ErrorHandler. Writes into `Collection` class.
        /// </summary>
        public abstract void LoadData();
        public virtual bool SaveRecord(T record)
        {
            if (record == null)
                throw new NullReferenceException($"{nameof(DatabaseController<T>)}.{nameof(SaveRecord)}.{nameof(record)} is null");
            else
                return false;
        }
    }
}
