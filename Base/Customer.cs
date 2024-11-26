using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class Customer : TableRecord
    {
        public Customer() : base() { }
        public Customer(int? id) : base(id) { }
        public Customer(TableRecordKey key) : base(key) { }

        internal string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        internal Customer2Device? _customer2Device;
        public Customer2Device? Customer2Device
        {
            get => _customer2Device;
            set => SetProperty(ref _customer2Device, value);
        }

        public override void CopyValuesFrom(IRecord other)
        {
            if (!(other is Customer))
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Customer)}");

            Customer Other = (Customer)other;
            Name = Other.Name;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            string hashString = $"{Key};{Name}";
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(hashString));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
