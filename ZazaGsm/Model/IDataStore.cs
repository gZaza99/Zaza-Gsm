using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Base;

namespace ZazaGsm.Model
{
    public interface IDataStore<Record> where Record : IRecord
    {
        bool Add(Record record);
        bool Modify(Record record, Record newRecord);
        bool Delete(Record record);

        Record? First(Func<Record, bool> filter);
        List<Record>? Where(Func<Record, bool> filter);
    }
}
