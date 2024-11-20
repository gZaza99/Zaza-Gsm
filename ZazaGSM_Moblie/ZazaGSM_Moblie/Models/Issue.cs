using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public class Issue : TableRecord
    {
        #region Constructor
        public Issue() : base()
        {
            Status = IssueStatus.Teendő;
        }
        public Issue(TableRecordKey key) : base(key) { }
        public Issue(int Id) : base(Id) { }
        #endregion
        #region Properties
        public string Complaint { get; set; } = string.Empty;
        public bool IsPayed { get; set; } = false;
        public bool IsAccepted { get; set; } = false;
        public string Opinion { get; set; } = string.Empty;
        public int? Quotation { get; set; } = null;
        public string Currency { get; set; } = "HUF";
        public IssueStatus Status { get; set; } = IssueStatus.Teendő;
        public string StatusReason { get; set; } = string.Empty;
        public Device? Device { get; set; } = null;
        public string Association => $"#{TableKey.Id} - {Complaint}";
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Issue))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Issue)}");

            Issue Other = (Issue)other;
            Complaint = Other.Complaint;
            IsPayed = Other.IsPayed;
            IsAccepted = Other.IsAccepted;
            Opinion = Other.Opinion;
            Quotation = Other.Quotation;
            Currency = Other.Currency;
            Status = Other.Status;
            StatusReason = Other.StatusReason;
        }

        public override bool Equals(Equatable other)
        {
            bool justForDebug = GetHashCode() == other.GetHashCode();
            return justForDebug;
        }

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Complaint};{IsAccepted};{Opinion};{Quotation};{Currency};{Status};{StatusReason}";
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(UTF8.GetBytes(hashString));
            HashCode justForDebug = new HashCode(bytes);
            return justForDebug;
        }
        #endregion
    }
}
