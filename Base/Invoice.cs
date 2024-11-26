using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class Invoice : TableRecord
    {
        public Invoice() : base()
        {
            Items = new List<InvoiceItem>();
        }
        public Invoice(int? Id) : base(Id)
        {
            Items = new List<InvoiceItem>();
        }
        public Invoice(TableRecordKey key) : base(key)
        { 
            Items = new List<InvoiceItem>();
        }

        internal Customer? _customer;
        public Customer? Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
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
            set => SetProperty(
                ref _baseCurrency,
                (value != null) ? value.ToUpper() : value
            );
        }
        public List<InvoiceItem> Items { get; set; }

        public override void CopyValuesFrom(IRecord other)
        {
            Invoice Other = (Invoice)other;
            Items.Clear();
            foreach (var item in Other.Items)
                Items.Add(item);
            _customer = Other.Customer;
            BaseCurrency = Other.BaseCurrency;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Status};{TotalSum};{_baseCurrency}";
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
