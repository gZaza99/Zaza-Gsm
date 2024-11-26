using System;
using System.Collections.Generic;
using System.Text;

namespace ZazaGsm.Base
{
    public interface IRecord
    {
        public RecordKey Key { get; set; }
        public void CopyValuesFrom(IRecord other);
        public bool KeyIsSame(IRecord? other);
    }
}
