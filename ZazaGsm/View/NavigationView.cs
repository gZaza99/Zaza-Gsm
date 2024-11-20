using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZazaGsm.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ZazaGsm.View
{
    public partial class NavigationView : UserControl, IResizable
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        private void SetActiveButton(Button activeButton)
        {
            BtnSettings.BackColor = SystemColors.Control;
            BtnCustomers.BackColor = SystemColors.Control;
            BtnTasks.BackColor = SystemColors.Control;
            BtnDevices.BackColor = SystemColors.Control;
            BtnInvoices.BackColor = SystemColors.Control;
            activeButton.BackColor = SystemColors.Highlight;
        }

        private void NavButtonClick(object sender, EventArgs e)
        {
            if (sender == null)
                return;

            Button Sender = (Button)sender;
            if (this.ParentForm == null)
                throw new Exception($"Unexpected value in {nameof(NavigationView)}.{nameof(ParentForm)}. This property should not be NULL.");

            switch (Sender.Name)
            {
                case nameof(BtnSettings):
                    ((ZazaGSMForm)ParentForm).SwitchPageTo(typeof(SettingsView));
                    SetActiveButton(BtnSettings);
                    break;
                case nameof(BtnCustomers):
                    ((ZazaGSMForm)ParentForm).SwitchPageTo(typeof(CustomersView));
                    SetActiveButton(BtnCustomers);
                    break;
                case nameof(BtnTasks):
                    ((ZazaGSMForm)ParentForm).SwitchPageTo(typeof(IssuesView));
                    SetActiveButton(BtnTasks);
                    break;
                case nameof(BtnDevices):
                    ((ZazaGSMForm)ParentForm).SwitchPageTo(typeof(DevicesView));
                    SetActiveButton(BtnDevices);
                    break;
                case nameof(BtnInvoices):
                    ((ZazaGSMForm)ParentForm).SwitchPageTo(typeof(InvoicesView));
                    SetActiveButton(BtnInvoices);
                    break;
            }
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            Location = new Point(e.PanelSize.Width / 2 + e.PanelPadding - this.Size.Width / 2, this.Location.Y);
            return Task.CompletedTask;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            string caption = string.Empty;
            Button Sender = (Button)sender;
            /**/
            if (Sender.Name == BtnSettings.Name)
                caption = "Beállítások";
            else if (Sender.Name == BtnCustomers.Name)
                caption = "Ügyfelek";
            else if (Sender.Name == BtnTasks.Name)
                caption = "Feladatok";
            else if (Sender.Name == BtnDevices.Name)
                caption = "Készülékek";
            else if (Sender.Name == BtnInvoices.Name)
                caption = "Számlák";
            ToolTip.SetToolTip(Sender, caption);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ToolTip.SetToolTip((Button)sender, null);
        }
    }
}
