using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ZazaGSM_Moblie.Views
{
    public interface ISoundPlayer
    {
        public void Play(string relativePath);
    }
}
