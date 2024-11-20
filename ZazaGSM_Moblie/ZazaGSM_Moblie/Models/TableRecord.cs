using System;

namespace ZazaGSM_Moblie.Models
{
    public abstract class TableRecord : Equatable, IRecord
    {
        #region Constructors
        public TableRecord()
        {
            Key = new TableRecordKey(null);
        }
        public TableRecord(TableRecordKey key)
        {
            Key = key;
        }
        public TableRecord(int? id)
        {
            Key = new TableRecordKey(id);
        }
        #endregion
        #region Properties
        public RecordKey Key { get; set; }
        public TableRecordKey TableKey
        {
            get => (TableRecordKey)Key;
            set => Key = value;
        }
        #endregion
        #region Methods
        public abstract void CopyValuesFrom(IRecord other);

        public bool KeyIsSame(IRecord other)
        {
            if (other == null)
                return false;

            if (!(other is TableRecord))
                throw new Exception($"Unexpected argument in {nameof(TableRecord)}.{nameof(KeyIsSame)}");

            TableRecord otherRecord = (TableRecord)other;
            return TableKey == otherRecord.TableKey;
        }

        public bool KeyIsSame(int Id)
            => TableKey.Id == Id;

        public Type Ancestor => typeof(IRecord);
        #endregion
        #region Operators
        public static bool operator ==(TableRecord left, TableRecord right)
        {
            if (left is null ^ right is null)
                return false;
            if (left is null && right is null)
                return true;
            return left.Equals(right);
        }
        public static bool operator !=(TableRecord left, TableRecord right)
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
