using System;
using System.Collections.Generic;
using System.Text;

namespace ZazaGsm.Base
{
    public interface IScannable
    {
        string Barcode { get; set; }
        delegate void ScannedEventHandler(Device d);
        event ScannedEventHandler Scanned;
    }
}
