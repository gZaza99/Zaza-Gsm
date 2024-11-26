using System;

namespace ZazaGsm.Base
{
    public class HashCode
    {
        /// <summary>Hash code part 1</summary>
        private ulong _p1;
        /// <summary>Hash code part 2</summary>
        private ulong _p2;

        private byte[] _hash;

        /// <summary>Represents a 128bit code</summary>
        public HashCode(byte[] bytes)
        {
            if (bytes.Length != 16)
                throw new ArgumentException($"Length of {nameof(bytes)} is not 16");
            _hash = bytes;
            _p1 = 0; _p2 = 0;
            FromBytes(bytes);
        }

        private void FromBytes(byte[] hashBytes)
        {
            int i = 0;
            while (i < 8)
            {
                _p1 = _p1 << 8;
                _p1 |= hashBytes[i];
                i++;
            }
            while (i < 16)
            {
                _p2 = _p2 << 8;
                _p2 |= hashBytes[i];
                i++;
            }
        }
        public byte[] Bytes => _hash;
        public override string ToString() => $"{_p1:X16}{_p2:X16}";

        private bool Equals(HashCode obj) => _p1 == obj._p1 && _p2 == obj._p2;

        public static bool operator ==(HashCode left, ZazaGsm.Base.HashCode right)
        {
            if ((left is null) != (right is null))
                return false;
            if (left is null && right is null)
                return true;
            return left.Equals(right);
        }
        public static bool operator !=(HashCode left, ZazaGsm.Base.HashCode right)
        {
            if ((left is null) != (right is null))
                return true;
            if (left is null && right is null)
                return false;
            return !left.Equals(right);
        }
    }
}
