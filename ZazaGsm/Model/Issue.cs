using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class Issue : TableRecord
    {
        #region Constructor
        public Issue() : base() { }
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
        public DateOnly AnnouncementDate { get; set; }
        public DateOnly? ClosingDate { get; set; }
        #endregion
        #region Methods
        public object? GetProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Complaint):
                    return Complaint;
                case nameof(IsPayed):
                    return IsPayed;
                case nameof(IsAccepted):
                    return IsAccepted;
                case nameof(Opinion):
                    return Opinion;
                case nameof(Quotation):
                    return Quotation;
                case nameof(Currency):
                    return Currency;
                case nameof(Status):
                    return Status;
                case nameof(StatusReason):
                    return StatusReason;
                case nameof(AnnouncementDate):
                    return AnnouncementDate;
                case nameof(ClosingDate):
                    return ClosingDate;
                default:
                    return null;
            }
        }

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
            AnnouncementDate = Other.AnnouncementDate;
            ClosingDate = Other.ClosingDate;
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
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            HashCode justForDebug = new HashCode(bytes);
            return justForDebug;
        }
        #endregion
    }
}
