using ZazaGsm.Model;

namespace ZazaGsm.Controller
{
    public abstract class DbRelationController<T> : DatabaseController<T> where T : RelationRecord
    {
        public override bool IsRecordChanged(T record)
        {
            return base.IsRecordChanged(record);
        }

        public override bool SaveRecord(T record)
        {
            return base.SaveRecord(record);
        }
    }
}
