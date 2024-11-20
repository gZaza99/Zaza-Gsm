using System.Security.Cryptography;
using System.Text;
using System;

namespace ZazaGSM_Moblie.Models
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
            if (!(other is Customer))
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
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(UTF8.GetBytes(hashString));
            return new HashCode(bytes);
        }
        #endregion
    }
}