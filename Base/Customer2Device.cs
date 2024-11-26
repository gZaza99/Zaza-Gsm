using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGsm.Base
{
    public class Customer2Device : RelationRecord
    {
        public Customer2Device() : base() { }
        public Customer2Device(RelationRecordKey key) : base(key) { }
        public Customer2Device(int? idLeft, int? idRight) : base(idLeft, idRight) { }

        internal Customer? _customer;
        public Customer? Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        internal Device? _device;
        public Device? Device
        {
            get => _device;
            set => SetProperty(ref _device, value);
        }

        public override void CopyValuesFrom(IRecord other)
        {
            if (!(other is RelationRecord)) // NOT a RelationRecord
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Customer2Device)}");

            RelationKey = ((RelationRecord)other).RelationKey;
        }

        protected override void SetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            MD5 mD5 = MD5.Create();
            byte[] bytes = mD5.ComputeHash(UTF8.GetBytes(RelationKey.ToString()));
            Hash = new ZazaGsm.Base.HashCode(bytes);
        }
    }
}
