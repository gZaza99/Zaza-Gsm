using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class Device : TableRecord, IScannable
    {
        #region Constructors
        public Device() : base()
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Issues = new List<Issue>();
        }
        public Device(TableRecordKey key) : base(key)
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Issues = new List<Issue>();
        }
        public Device(int id) : base(id)
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Issues = new List<Issue>();
        }
        public Device(int id, string type) : base(id)
        {
            this._barcode = string.Empty;
            Type = type;
            Customer2Device = null;
            Issues = new List<Issue>();
        }
        #endregion
        #region DataMembers
        internal string? _barcode;
        internal string _type;
        internal Customer2Device? _customer2Device;
        internal List<Issue> _issues;
        #endregion
        #region Properties
        public string? Barcode
        {
            get => _barcode;
            set
            {
                SetProperty(ref _barcode, value);
                // If you don't want the scanning to be executed, then don't add delegate for Scanned event!
                Scanned?.Invoke(this);
            }
        }
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }
        public Customer2Device? Customer2Device
        {
            get => _customer2Device;
            set => SetProperty(ref _customer2Device, value);
        }
        public List<Issue> Issues
        {
            get => _issues;
            set => SetProperty(ref _issues, value);
        }
        #endregion
        #region Methods
        public Issue? GetLastIssue()
        {
            if (Issues.Count == 0)
                return null;
            Issue LastIssue = Issues[0];
            for (int index = 1; index < Issues.Count; index++)
            {
                if (LastIssue.AnnouncementDate < Issues[index].AnnouncementDate)
                    LastIssue = Issues[index];
            }
            return LastIssue;
        }

        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Device))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Device)}");

            Device Other = (Device)other;
            Type = Other.Type;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = string.IsNullOrEmpty(Barcode) ? $"{Key};{Type}" : Barcode;
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
        #endregion
        #region Events
        public event IScannable.ScannedEventHandler? Scanned;
        #endregion
    }
}
