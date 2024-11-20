using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public class Device : TableRecord, IScannable<Device>
    {
        #region Constructors
        public Device() : base()
            => this._barcode = string.Empty;
        public Device(string type) : base()
        {
            this.Type = type;
            this._barcode = string.Empty;
        }
        public Device(TableRecordKey key) : base(key)
            => this._barcode = string.Empty;
        public Device(int id) : base(id)
            => this._barcode = string.Empty;
        public Device(string type, string barcode) : base()
        {
            this.Type = type;
            this._barcode = barcode;
        }
        public Device(TableRecordKey key, string barcode) : base(key)
            => this._barcode = barcode;
        public Device(int id, string barcode) : base(id)
            => this._barcode = barcode;
        #endregion
        #region Properties
        private string _barcode;
        public string Barcode
        {
            get => _barcode;
            set
            {
                _barcode = value;
                if (!string.IsNullOrEmpty(value))
                    Scanned.Invoke(this);
            }
        }
        public string Type { get; set; } = string.Empty;
        public string? FrontImagePath { get; set; }
        public string? BackImagePath { get; set; }
        public Customer2Device? Customer2Device { get; set; }
        public string Association => $"#{TableKey.Id} - {Type}";
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Device))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Device)}");

            Device Other = (Device)other;
            Type = Other.Type;
            FrontImagePath = Other.FrontImagePath;
        }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = string.IsNullOrEmpty(Barcode) ? $"{Key};{Type};{FrontImagePath}" : Barcode;
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
        #region Events
        public event IScannable<Device>.ScannedEventHandler Scanned;
        #endregion
    }
}
