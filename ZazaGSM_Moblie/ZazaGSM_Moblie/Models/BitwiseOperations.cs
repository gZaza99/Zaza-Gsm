using System.Runtime.InteropServices;

namespace ZazaGSM_Moblie.Models
{
    public static class BitwiseOperations
    {
        [DllImport("Numerics.dll")]
        public static extern ulong RotateRight(ulong target, byte offset);

        [DllImport("Numerics.dll")]
        public static extern ulong RotateLeft(ulong target, byte offset);

        [DllImport("Numerics.dll")]
        public static extern ulong ShiftRight(ulong target, byte offset);

        [DllImport("Numerics.dll")]
        public static extern ulong ShiftLeft(ulong target, byte offset);
    }
}
