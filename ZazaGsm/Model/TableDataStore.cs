namespace ZazaGsm.Model
{
    public class TableDataStore<Table> : BaseDataStore<Table> where Table : TableRecord
    {
        private void CheckRecordKeyType(RecordKey key)
        {
            if (key is not TableRecordKey)
                throw new ArgumentException($"Unexpected argument in {nameof(TableDataStore<Table>)}.{nameof(CheckRecordKeyType)}");
        }

        public override int IndexOf(RecordKey key)
        {
            CheckRecordKeyType(key);
            TableRecordKey Key = (TableRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].TableKey == Key)
                    return index;
            return -1;
        }

        public override bool Contains(RecordKey key)
        {
            CheckRecordKeyType(key);
            TableRecordKey Key = (TableRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].TableKey == Key)
                    return true;
            return false;
        }

        public override bool Delete(RecordKey key)
        {
            CheckRecordKeyType(key);
            TableRecordKey Key = (TableRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].TableKey == Key)
                {
                    _records.RemoveAt(index);
                    return true;
                }
            return false;
        }

        public override bool Modify(RecordKey key, Table newRecord)
        {
            CheckRecordKeyType(key);
            TableRecordKey Key = (TableRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].TableKey == Key)
                {
                    base[index].CopyValuesFrom(newRecord);
                    return true;
                }
            return false;
        }
    }
}
