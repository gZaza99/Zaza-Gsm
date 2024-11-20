using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class Invoice : TableRecord
    {
        #region Constructors
        public Invoice() : base()
        { Items = new List<InvoiceItem>(); }
        public Invoice(int? Id) : base(Id)
        { Items = new List<InvoiceItem>(); }
        public Invoice(TableRecordKey key) : base(key)
        { Items = new List<InvoiceItem>(); }
        #endregion
        #region Properties
        public Customer? Customer { get; set; }
        public int TotalSum
        {
            get
            {
                int sum = 0;
                for (int index = 0; index < Items.Count; index++)
                {
                    if (Items[index].Currency == BaseCurrency)
                        sum += Items[index].Sum;
                }
                return sum;
            }
        }
        public InvoiceStatus Status
        {
            get
            {
                if (Items.Count == 0)
                    return InvoiceStatus.Új;
                InvoiceStatus[] statuses = new InvoiceStatus[Items.Count];
                for (int index = 0; index < Items.Count; index++)
                    statuses[index] = Items[index].ItemsStatus;
                return statuses.Min();
            }
        }

        private string? _baseCurrency;
        public string? BaseCurrency
        {
            get => _baseCurrency;
            set => _baseCurrency = (value != null) ? value.ToUpper() : value;
        }
        public List<InvoiceItem> Items { get; set; }
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            Invoice Other = (Invoice)other;
            BaseCurrency = Other.BaseCurrency;
            Items.Clear();
            foreach (var item in Other.Items)
                Items.Add(item);
        }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Status};{TotalSum};{_baseCurrency}";
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
    }
}
