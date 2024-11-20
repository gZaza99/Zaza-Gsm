namespace ZazaGsm.Model
{
    public interface IScannable
    {
        string Barcode { get; set; }
        delegate void ScannedEventHandler();
        event ScannedEventHandler Scanned;
    }
}
