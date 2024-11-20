namespace ZazaGsm.Model
{
    public abstract class BaseDataStore<Record> : IDataStore<Record>, IDisposable where Record : IRecord
    {
        protected List<Record> _records = new();
        public int Count => _records.Count();

        public List<Record> GetAll() => _records;

        /// <exception cref="Exception"></exception>
        public Record First(Func<Record, bool> filter)
        {
            for (int index = 0; index < Count; index++)
                if (filter.Invoke(this[index]))
                    return this[index];
            throw new Exception("Data not found.");
        }

        public Record? FirstOrDefault(Func<Record, bool> filter)
        {
            Record justForDebug;
            for (int index = 0; index < Count; index++)
            {
                justForDebug = this[index];
                if (filter.Invoke(justForDebug))
                    return justForDebug;
            }
            return default;
        }

        public List<Record>? Where(Func<Record, bool> filter)
        {
            List<Record>? result = new List<Record>();
            for (int index = 0; index < Count; index++)
                if (filter.Invoke(this[index]))
                    result.Add(this[index]);
            return result.Count > 0 ? result : null;
        }

        public Record this[int index]
        {
            get => _records.ElementAt(index);
            private set => _records.ElementAt(index).CopyValuesFrom(value);
        }

        public abstract int IndexOf(RecordKey key);

        public int IndexOf(Record record)
        {
            for (int i = 0; i < _records.Count(); i++)
                if (_records.ElementAt(i).KeyIsSame(record))
                    return i;
            return -1;
        }

        public bool Contains(Record record)
        {
            return _records.Contains(record);
        }
        public abstract bool Contains(RecordKey key);

        public bool Add(Record record)
        {
            if (this.Contains(record))
                return false;

            _records.Add(record);
            return true;
        }

        public bool Modify(Record record, Record newRecord)
        {
            int index = this.IndexOf(record);
            if (index == -1) // DOESN'T CONTAINS
                return false;

            this[index] = newRecord;
            return true;
        }

        public abstract bool Modify(RecordKey key, Record newRecord);

        public abstract bool Delete(RecordKey key);
        public bool Delete(Record record)
        {
            if (!this.Contains(record)) // DOES NOT CONTAINS
                return false;

            _records.RemoveAt(IndexOf(record));
            return true;
        }

        public void Clear()
        {
            _records.Clear();
        }

        public void Dispose()
        {
            _records.Clear();
        }
    }
}
