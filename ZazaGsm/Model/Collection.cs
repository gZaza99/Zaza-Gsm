using ZazaGsm.Base;

namespace ZazaGsm.Model
{
    public static class Collection
    {
        public static TableDataStore<Customer> CustomerDataStore = new();
        public static TableDataStore<Issue> TaskDataStore = new();
        public static TableDataStore<Device> DeviceDataStore = new();
        public static RelationDataStore<Customer2Device> Customer2DeviceDataStore = new();
        public static TableDataStore<Invoice> InvoiceDataStore = new();
        public static TableDataStore<InvoiceItem> InvoiceItemDataStore = new();
    }
}
