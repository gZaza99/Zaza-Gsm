namespace ZazaGsm.Model
{
    public abstract class RecordKey : IEquatable<RecordKey>
    {
        public abstract bool Equals(RecordKey? other);
        public abstract new string ToString();
    }
}