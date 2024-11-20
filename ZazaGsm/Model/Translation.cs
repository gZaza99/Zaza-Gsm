using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZazaGsm.Model
{
    public enum Text
    {
        T0000,
        T0001,
        T0002,
        T0003,
        T0004,
        T0005,
        T0006,
        T0007,
        T0008,
        T0009,
        T0010,
        T0011,
        T0012,
        T0013,
        T0014,
        T0015,
        T0016,
        T0017,
        T0018,
        T0019,
        T0020,
        T0021,
        T0022,
        T0023,
        T0024,
        T0025,
        T0026,
        T0027,
        T0028,
        T0029,
        T0030
    }

    public enum Language
    {
        ENG,
        HUN
    }

    public static class Translation
    {
        public static readonly string[] ENG = (new List<string>() {

        }).ToArray();
        public static readonly string[] HUN = (new List<string>() {
            
        }).ToArray();
        
        public static string Get(Text text, Language language)
        {
            switch (language)
            {
                case Language.ENG:
                    return ENG[(int)text];
                case Language.HUN:
                    return HUN[(int)text];
                default:
                    Debug.WriteLine($"Unexpected language in {nameof(Translation)}.{nameof(Get)}: {language.ToString()}");
                    return string.Empty;
            }
        }
    }
}
