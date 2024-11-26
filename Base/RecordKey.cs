using System;
using System.Collections.Generic;
using System.Text;

namespace ZazaGsm.Base
{
    public abstract class RecordKey : IEquatable<RecordKey>
    {
        public abstract bool Equals(RecordKey? other);
        public abstract new string ToString();
    }
}
