using System.Threading.Tasks;

namespace ZazaGSM_Moblie.Models
{
    public interface IScannable<T>
    {
        string Barcode { get; set; }
        delegate void ScannedEventHandler(T obj);
        event ScannedEventHandler Scanned;
    }
}
