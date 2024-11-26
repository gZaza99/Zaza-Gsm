using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class Issue : TableRecord
    {
        public Issue() : base()
        {
            Initialize();
        }
        public Issue(TableRecordKey key) : base(key)
        {
            Initialize();
        }
        public Issue(int Id) : base(Id)
        {
            Initialize();
        }

        private void Initialize()
        {
            _complaint = string.Empty;
            _isPayed = false;
            _isAccepted = false;
            _opinion = string.Empty;
            _currency = "HUF";
            _status = IssueStatus.Teendő;
            _statusReason = string.Empty;
        }

        internal string _complaint;
        public string Complaint
        {
            get => _complaint;
            set => SetProperty(ref _complaint, value);
        }
        internal bool _isPayed;
        public bool IsPayed
        {
            get => _isPayed;
            set => SetProperty(ref _isPayed, value);
        }
        internal bool _isAccepted;
        public bool IsAccepted
        {
            get => _isAccepted;
            set => SetProperty(ref _isAccepted, value);
        }
        internal string _opinion;
        public string Opinion
        {
            get => _opinion;
            set => SetProperty(ref _opinion, value);
        }
        internal int? _quotation;
        public int? Quotation
        {
            get => _quotation;
            set => SetProperty(ref _quotation, value);
        }
        internal string _currency;
        public string Currency
        {
            get => _currency;
            set => SetProperty(ref _currency, value);
        }
        internal IssueStatus _status;
        public IssueStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        internal string _statusReason;
        public string StatusReason
        {
            get => _statusReason;
            set => SetProperty(ref _statusReason, value);
        }
        internal Device? _device;
        public Device? Device
        {
            get => _device;
            set => SetProperty(ref _device, value);
        }
        internal DateTime _announcementDate;
        public DateTime AnnouncementDate
        {
            get => _announcementDate;
            set => SetProperty(ref _announcementDate, value);
        }
        internal DateTime? _closingDate;
        public DateTime? ClosingDate
        {
            get => _closingDate;
            set => SetProperty(ref _closingDate, value);
        }
        internal DeviceImage? _deviceImage;
        public DeviceImage? DeviceImage
        {
            get => _deviceImage;
            set => SetProperty(ref _deviceImage, value);
        }

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
            _complaint = Other.Complaint;
            _isPayed = Other.IsPayed;
            _isAccepted = Other.IsAccepted;
            _opinion = Other.Opinion;
            _quotation = Other.Quotation;
            _currency = Other.Currency;
            _status = Other.Status;
            _statusReason = Other.StatusReason;
            _announcementDate = Other.AnnouncementDate;
            ClosingDate = Other.ClosingDate;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Complaint};{IsAccepted};{Opinion};{Quotation};{Currency};{Status};{StatusReason}";
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
