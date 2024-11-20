using System;

namespace ZazaGSM_Moblie.Models
{
    public class RelationRecordKey : RecordKey
    {
        public RelationRecordKey(int? idLeft, int? idRight)
        {
            IdLeft = idLeft;
            IdRight = idRight;
        }

        public int? IdLeft { get; }
        public int? IdRight { get; }

        public override bool Equals(RecordKey? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (other.GetType() != typeof(RelationRecordKey))
                throw new ArgumentException($"Unexpected argument in {nameof(RelationRecordKey)}.{nameof(Equals)}");

            RelationRecordKey otherKey = (RelationRecordKey)other;
            return IdLeft == otherKey.IdLeft &&
                   IdRight == otherKey.IdRight;
        }

        public override string ToString()
        {
            return $"{IdLeft};{IdRight}";
        }

        public static bool operator ==(RelationRecordKey left, RelationRecordKey right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(RelationRecordKey left, RelationRecordKey right)
        {
            return !Equals(left, right);
        }
    }
}