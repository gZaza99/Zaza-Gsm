using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZazaGsm.Model;

namespace ZazaGsm.View
{
    public partial class MessageBar : UserControl, IResizable
    {
        public MessageBar()
        {
            InitializeComponent();
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            Size = new Size(e.PanelSize.Width - e.PanelPadding, Size.Height);
            BtnClose.Location = new Point(ClientSize.Width - BtnClose.Width);
            return Task.CompletedTask;
        }
    }
}
