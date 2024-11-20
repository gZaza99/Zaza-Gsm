using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class Device : TableRecord, IScannable
    {
        #region Constructors
        public Device() : base()
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Images = new List<DeviceImage>();
        }
        public Device(TableRecordKey key) : base(key)
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Images = new List<DeviceImage>();
        }
        public Device(int id) : base(id)
        {
            this._barcode = string.Empty;
            Type = string.Empty;
            Customer2Device = null;
            Images = new List<DeviceImage>();
        }
        #endregion
        #region Properties
        private string? _barcode;
        public string? Barcode
        {
            get => _barcode;
            set
            {
                _barcode = value;
                Scanned?.Invoke();
            }
        }
        public string Type { get; set; }
        public Customer2Device? Customer2Device { get; set; }
        public List<DeviceImage> Images { get; set; }
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            if (other.GetType() != typeof(Device))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Device)}");

            Device Other = (Device)other;
            Type = Other.Type;
        }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = string.IsNullOrEmpty(Barcode) ? $"{Key};{Type}" : Barcode;
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
        #region Events
        public event IScannable.ScannedEventHandler? Scanned;
        #endregion
    }
}
