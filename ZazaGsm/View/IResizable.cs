using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;

namespace ZazaGsm.View
{
    internal interface IResizable
    {
        Task OnResize(DrawableSizeEventArgs e);
    }
}
