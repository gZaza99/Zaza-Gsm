using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ZazaGsm.Base
{
    public abstract class RelationRecord : Equatable, IRecord
    {
        #region Constructors
        public RelationRecord() : base()
        {
            Key = new RelationRecordKey(null, null);
        }
        public RelationRecord(RelationRecordKey key) : base()
        {
            Key = key;
        }
        public RelationRecord(int? idLeft, int? idRight) : base()
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

        public bool KeyIsSame(IRecord? other)
        {
            if (other == null)
                return false;

            if (!(other is RelationRecord))
                throw new Exception($"Unexpected argument in {nameof(RelationRecord)}.{nameof(KeyIsSame)}");

            RelationRecord otherRecord = (RelationRecord)other;
            return RelationKey == otherRecord.RelationKey;
        }
        #endregion
    }
}
