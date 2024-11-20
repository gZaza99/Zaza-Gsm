using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZazaGsm.Model
{
    public class DrawableSizeEventArgs : EventArgs
    {
        public DrawableSizeEventArgs(Size panelSize, int panelPadding)
        {
            this.PanelSize = panelSize;
            this.PanelPadding = panelPadding;
        }
        public Size PanelSize { get; private set; }
        public int PanelPadding { get; private set; }
    }
}
