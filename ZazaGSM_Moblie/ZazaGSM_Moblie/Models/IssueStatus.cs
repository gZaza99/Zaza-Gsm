using System;
using System.Collections.Generic;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public enum IssueStatus
    {
        Teendő,
        Folyamatban,
        Ajánlat,
        Blokkolt,
        Meghiúsult,
        Számla,
        Átadás,
        Lezárt,
        NULL
    }

    public enum InvoiceStatus
    {
        Új,
        Nyitott,
        Lezárt,
        NULL
    }
}
