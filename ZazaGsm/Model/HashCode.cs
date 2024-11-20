using System.Numerics;

namespace ZazaGsm.Model
{
    public class HashCode
    {
        #region Members
        /// <summary>part 1</summary>
        ulong p1;
        /// <summary>part 2</summary>
        ulong p2;
        #endregion
        #region Constructors
        public HashCode()
        {
            p1 = 0;
            p2 = 0;
        }
        public HashCode(byte[] hashBytes)
        {
            p1 = 0;
            p2 = 0;
            FromBytes(hashBytes);
        }
        #endregion
        #region Methods
        public void FromBytes(byte[] hashBytes)
        {
            if (hashBytes.Length != 16)
                throw new ArgumentException($"Length of {nameof(hashBytes)} is not 16");
            int i = 0;
            while (i < 8)
            {
                p1 |= hashBytes[i];
                p1 = BitOperations.RotateRight(p1, 8);
                i++;
            }
            while (i < 16)
            {
                p2 |= hashBytes[i];
                p2 = BitOperations.RotateRight(p2, 8);
                i++;
            }
        }

        public byte[] ToBytes()
        {
            byte[] hashBytes = new byte[16];
            int i = 16;
            while (--i > 8)
            {
                hashBytes[i] = (byte)p2;
                p2 >>= 8;
            }
            while (i >= 0)
            {
                hashBytes[i] = (byte)p1;
                p1 >>= 8;
                i--;
            }

            return hashBytes;
        }
        public override string ToString() => $"{p1:X}{p2:X}";

        private bool Equals(HashCode obj) => p1 == obj.p1 && p2 == obj.p2;
        #endregion
        #region Operators
        public static bool operator ==(HashCode left, HashCode right)
        {
            if (left is null ^ right is null)
                return false;
            if (left is null && right is null)
                return true;
            return left.Equals(right);
        }
        public static bool operator !=(HashCode left, HashCode right)
        {
            if (left is null ^ right is null)
                return true;
            if (left is null && right is null)
                return false;
            return !left.Equals(right);
        }
        #endregion
    }
}
