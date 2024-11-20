using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class InvoiceItem : TableRecord
    {
        #region Constructors
        public InvoiceItem() : base() { }
        public InvoiceItem(TableRecordKey key) : base(key) { }
        public InvoiceItem(int id) : base(id) { }
        #endregion
        #region Properties
        public string? Remarks { get; set; }
        public int Sum { get; set; } = 0;
        private string _currency = string.Empty;
        public string Currency
        {
            get => _currency;
            set => _currency = value.ToUpper();
        }
        public Invoice? Invoice { get; set; }
        public InvoiceStatus ItemsStatus { get; set; } = InvoiceStatus.Új;
        public Issue? Issue { get; set; }
        public bool IsPurchase { get; set; }
        public DateOnly? PaymentDate { get; set; }
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            InvoiceItem Other = (InvoiceItem)other;
            Remarks = Other.Remarks;
            Sum = Other.Sum;
            Currency = Other.Currency;
            Issue = Other.Issue;
        }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Remarks};{Sum};{Currency};{ItemsStatus}";
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
    }
}
