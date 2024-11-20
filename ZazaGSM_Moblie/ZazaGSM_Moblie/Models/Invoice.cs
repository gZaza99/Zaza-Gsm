using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public class Invoice : TableRecord
    {
        string Description { get; set; }
        public Customer Customer { get; set; }
        public int SumTotal { get; set; }
        public string BaseCurrency { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<InvoiceItem> Items { get; private set; }
        public string Association => $"(#{TableKey.ToString()}) {SumTotal} {BaseCurrency} - {Customer?.Name}";
        public Invoice() { }
        public override void CopyValuesFrom(IRecord other)
        {
            if (!(other is Invoice))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Invoice)}");

            Invoice Other = (Invoice)other;
            this.Description = Other.Description;
            this.Customer = Other.Customer;
            this.SumTotal = Other.SumTotal;
            this.BaseCurrency = Other.BaseCurrency;
        }

        public override bool Equals(Equatable obj)
            => GetHashCode() == obj.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Description};{Customer.TableKey};{SumTotal};{BaseCurrency}";
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
    }
}
