using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Base
{
    public abstract class Equatable
    {
        protected HashCode Hash;
        public HashCode HashCode => Hash;
        protected MD5 mD5;
        public Equatable()
        {
            mD5 = MD5.Create();
        }
        public virtual bool Equals(Equatable other) => Hash == other.Hash;

        public static bool operator ==(Equatable? left, Equatable? right)
        {
            if (left is null ^ right is null)
                return false;
            if (left is null && right is null)
                return true;
            return left.Equals(right);
        }
        public static bool operator !=(Equatable? left, Equatable? right)
        {
            if (left is null ^ right is null)
                return true;
            if (left is null && right is null)
                return false;
            return !left.Equals(right);
        }
        public void SetProperty<T>(ref T pointer, T value)
        {
            pointer = value;
            SetHashCode();
        }
        protected abstract void SetHashCode();
    }
}
