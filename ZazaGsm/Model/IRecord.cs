namespace ZazaGsm.Model
{
    public interface IRecord
    {
        public RecordKey Key { get; set; }
        public void CopyValuesFrom(IRecord other);
        public bool KeyIsSame(IRecord? other);
    }
}