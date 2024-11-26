using ZazaGsm.Model;
using ZazaGsm.Base;

namespace ZazaGsm.Controller
{
    public interface IDatabaseController<T> where T : IRecord
    {
        bool IsRecordExists(T record);
        bool IsRecordChanged(T record);
        void LoadData();
        bool SaveRecord(T record);
    }
}
