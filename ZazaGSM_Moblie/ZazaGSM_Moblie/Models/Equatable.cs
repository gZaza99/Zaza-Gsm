namespace ZazaGSM_Moblie.Models
{
    public abstract class Equatable
    {
        public abstract bool Equals(Equatable obj);
        public static bool operator ==(Equatable left, Equatable right)
        {
            if (left is null ^ right is null)
                return false;
            if (left is null && right is null)
                return true;
            return left.Equals(right);
        }
        public static bool operator !=(Equatable left, Equatable right)
        {
            if (left is null ^ right is null)
                return true;
            if (left is null && right is null)
                return false;
            return !left.Equals(right);
        }
        public abstract new HashCode GetHashCode();
    }
}