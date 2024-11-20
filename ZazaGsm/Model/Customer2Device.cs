namespace ZazaGsm.Model
{
    public class Customer2Device : RelationRecord
    {
        #region Constructors
        public Customer2Device() : base() { }
        public Customer2Device(RelationRecordKey key) : base(key) { }
        public Customer2Device(int? idLeft, int? idRight) : base(idLeft, idRight) { }
        #endregion
        #region Properties
        public Customer? Customer { get; set; }
        public Device? Device { get; set; }
        #endregion
        #region Methods
        public override void CopyValuesFrom(IRecord other)
        {
            if (!(other is RelationRecord)) // NOT a RelationRecord
                throw new ArgumentException($"Type incompatibility in method {nameof(CopyValuesFrom)} in {nameof(Customer2Device)}");

            RelationKey = ((RelationRecord)other).RelationKey;
        }
        #endregion
    }
}
