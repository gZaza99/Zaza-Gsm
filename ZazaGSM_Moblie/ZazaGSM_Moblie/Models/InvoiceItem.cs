using System;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public class InvoiceItem : TableRecord
    {
        public int Sum { get; set; }
        public string Currency { get; set; }
        public string Remarks { get; set; }
        public bool IsPurchase { get; set; }
        public bool IsStorno { get; set; }
        public InvoiceStatus Status { get; set; }
        public Invoice ContainerInvoice { get; set; }
        public Issue AssignedIssue { get; set; }

        public InvoiceItem() { }

        public override void CopyValuesFrom(IRecord other)
        {
            if (!(other is InvoiceItem))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(InvoiceItem)}");

            InvoiceItem Other = (InvoiceItem)other;
            Sum = Other.Sum;
            Currency = Other.Currency;
            Remarks = Other.Remarks;
            IsPurchase = Other.IsPurchase;
            IsStorno = Other.IsStorno;
            Status = Other.Status;
            ContainerInvoice = Other.ContainerInvoice;
            AssignedIssue = Other.AssignedIssue;
        }

        public override bool Equals(Equatable obj)
            => GetHashCode() == obj.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Sum};{Remarks};{IsPurchase};{IsStorno};{Status};{ContainerInvoice.TableKey};{AssignedIssue.TableKey}";
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
    }
}