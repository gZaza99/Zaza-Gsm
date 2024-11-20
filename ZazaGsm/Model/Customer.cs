using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class Customer : TableRecord
    {
        #region Constructors
        public Customer() : base() { }
        public Customer(int? id) : base(id) { }
        public Customer(TableRecordKey key) : base(key) { }
        #endregion
        #region Properties
        public string? Name { get; set; }
        public int Dept { get; set; } = 0;
        public Customer2Device? Customer2Device { get; set; }
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            if (other is not Customer)
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Customer)}");

            Customer Other = (Customer)other;
            Name = Other.Name;
            Dept = Other.Dept;
        }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Name};{Dept}";
            byte[] bytes = MD5.HashData(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
    }
}
