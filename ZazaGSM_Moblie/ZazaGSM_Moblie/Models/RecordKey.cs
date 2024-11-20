using System;

namespace ZazaGSM_Moblie.Models
{
    public abstract class RecordKey : IEquatable<RecordKey>
    {
        public abstract bool Equals(RecordKey other);
        public abstract new string ToString();
    }
}
