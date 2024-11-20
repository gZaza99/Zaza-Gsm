using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Model
{
    public class RelationRecord : Equatable, IRecord
    {
        #region Constructors
        public RelationRecord()
        {
            Key = new RelationRecordKey(null, null);
        }
        public RelationRecord(RelationRecordKey key)
        {
            Key = key;
        }
        public RelationRecord(int? idLeft, int? idRight)
        {
            Key = new RelationRecordKey(idLeft, idRight);
        }
        #endregion
        #region Properties
        public RecordKey Key { get; set; }
        public RelationRecordKey RelationKey
        {
            get => (RelationRecordKey)Key;
            set => Key = value;
        }
        #endregion
        #region Methods
        public virtual void CopyValuesFrom(IRecord other) { }

        public override bool Equals(Equatable other)
            => GetHashCode() == other.GetHashCode();

        public override HashCode GetHashCode()
        {
            Encoding UTF8 = Encoding.UTF8;
            byte[] bytes = MD5.HashData(UTF8.GetBytes(Key.ToString()));
            return new HashCode(bytes);
        }

        public bool KeyIsSame(IRecord? other)
        {
            if (other == null)
                return false;

            if (other is not RelationRecord)
                throw new Exception($"Unexpected argument in {nameof(RelationRecord)}.{nameof(KeyIsSame)}");

            RelationRecord otherRecord = (RelationRecord)other;
            return RelationKey == otherRecord.RelationKey;
        }
        #endregion
    }
}
