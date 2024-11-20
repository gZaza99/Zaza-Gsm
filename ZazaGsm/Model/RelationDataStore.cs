namespace ZazaGsm.Model
{
    public class RelationDataStore<Relation> : BaseDataStore<Relation> where Relation : RelationRecord
    {
        private void CheckRecordKeyType(RecordKey key)
        {
            if (key is not RelationRecordKey)
                throw new ArgumentException($"Unexpected argument in {nameof(RelationDataStore<Relation>)}.{nameof(CheckRecordKeyType)}");
        }

        public override bool Contains(RecordKey key)
        {
            CheckRecordKeyType(key);
            RelationRecordKey Key = (RelationRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].RelationKey == Key)
                    return true;
            return false;
        }

        public override bool Delete(RecordKey key)
        {
            CheckRecordKeyType(key);
            RelationRecordKey Key = (RelationRecordKey)key;

            for (int index = 0; index < base.Count; index++)
                if (base[index].RelationKey == Key)
                {
                    _records.RemoveAt(index);
                    return true;
                }
            return false;
        }

        public override int IndexOf(RecordKey key)
        {
            CheckRecordKeyType(key);
            RelationRecordKey Key = (RelationRecordKey)key;
            for (int index = 0; index < base.Count; index++)
                if (base[index].RelationKey == Key)
                    return index;
            return -1;
        }

        public override bool Modify(RecordKey key, Relation newRecord)
        {
            CheckRecordKeyType(key);
            RelationRecordKey Key = (RelationRecordKey)key;
            for (int index = 0; index < base.Count; index++)
                if (base[index].RelationKey == Key)
                {
                    base[index].CopyValuesFrom(newRecord);
                    return true;
                }
            return false;
        }
    }
}
