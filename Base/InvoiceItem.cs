using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class InvoiceItem : TableRecord
    {
        public InvoiceItem() : base()
        {
            _sum = 0;
            _itemStatus = InvoiceStatus.Új;
        }
        public InvoiceItem(TableRecordKey key) : base(key)
        {
            _sum = 0;
            _itemStatus = InvoiceStatus.Új;
        }
        public InvoiceItem(int id) : base(id)
        {
            _sum = 0;
            _itemStatus = InvoiceStatus.Új;
        }

        internal string? _remarks;
        public string? Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
        internal int _sum;
        public int Sum
        {
            get => _sum;
            set => SetProperty(ref _sum, value);
        }
        internal string _currency = string.Empty;
        public string Currency
        {
            get => _currency;
            set => SetProperty(ref _currency, value.ToUpper());
        }
        internal Invoice? _invoice;
        public Invoice? Invoice
        {
            get => _invoice;
            set => SetProperty(ref _invoice, value);
        }
        internal InvoiceStatus _itemStatus;
        public InvoiceStatus ItemsStatus
        {
            get => _itemStatus;
            set => SetProperty(ref _itemStatus, value);
        }
        internal Issue? _issue;
        public Issue? Issue
        {
            get => _issue;
            set => SetProperty(ref _issue, value);
        }
        internal bool _isPurchase;
        public bool IsPurchase
        {
            get => _isPurchase;
            set => SetProperty(ref _isPurchase, value);
        }
        internal DateTime? _paymentDate;
        public DateTime? PaymentDate
        {
            get => _paymentDate;
            set => SetProperty(ref _paymentDate, value);
        }

        public override void CopyValuesFrom(IRecord other)
        {
            InvoiceItem Other = (InvoiceItem)other;
            _invoice = Other.Invoice;
            _remarks = Other.Remarks;
            _sum = Other.Sum;
            _currency = Other.Currency;
            _isPurchase = Other.IsPurchase;
            _paymentDate = Other.PaymentDate;
            Issue = Other.Issue;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Remarks};{Sum};{Currency};{ItemsStatus}";
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
