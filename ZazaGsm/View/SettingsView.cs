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
using ZazaGsm.Controller;
using ZazaGsm.Model;
using ZazaGsm.Base;

namespace ZazaGsm.View
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            ZazaGSMForm.AppSettings.PropertyChanged += Settings_PropertyChanged;
            ZazaGSMForm.AppSettings.SettingsSaving += CtrlSettings.SaveSettings;
        }

        public bool TryLoadSettings()
        {
            try
            {
                CtrlSettings.LoadSettings();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem sikerült betölteni a beállításokat. \n" + ex.Message, "Beállítás hiba");
                return false;
            }
        }

        private void Settings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ZazaGSMForm.AppSettings.DbAddress):
                    if (inpDbAddress.InvokeRequired)
                        inpDbAddress.Invoke(() => inpDbAddress.Text = ZazaGSMForm.AppSettings.DbAddress);
                    else
                        inpDbAddress.Text = ZazaGSMForm.AppSettings.DbAddress;
                    break;
                case nameof(ZazaGSMForm.AppSettings.DbName):
                    if (inpDbName.InvokeRequired)
                        inpDbName.Invoke(() => inpDbName.Text = ZazaGSMForm.AppSettings.DbName);
                    else
                        inpDbName.Text = ZazaGSMForm.AppSettings.DbName;
                    break;
                case nameof(ZazaGSMForm.AppSettings.UsrName):
                    if (inpUsrName.InvokeRequired)
                        inpUsrName.Invoke(() => inpUsrName.Text = ZazaGSMForm.AppSettings.UsrName);
                    else
                        inpUsrName.Text = ZazaGSMForm.AppSettings.UsrName;
                    break;
                case nameof(ZazaGSMForm.AppSettings.UsrPassword):
                    if (inpUsrPassword.InvokeRequired)
                        inpUsrPassword.Invoke(() => inpUsrPassword.Text = ZazaGSMForm.AppSettings.UsrPassword);
                    else
                        inpUsrPassword.Text = ZazaGSMForm.AppSettings.UsrPassword;
                    break;
            }
        }

        private void Inp_Leave(object sender, EventArgs e)
        {
            TextBox Sender = (TextBox)sender;
            switch (Sender.Name)
            {
                case nameof(inpDbAddress):
                    if (ZazaGSMForm.AppSettings.DbAddress != Sender.Text)
                    {
                        ZazaGSMForm.AppSettings.SetProperty(Settings.DbAddressProperty, Sender.Text, false);
                        _ = Task.Run(ZazaGSMForm.AppSettings.FireSettingsSaving);
                    }
                    break;
                case nameof(inpUsrName):
                    if (ZazaGSMForm.AppSettings.UsrName != Sender.Text)
                    {
                        ZazaGSMForm.AppSettings.SetProperty(Settings.UsrNameProperty, Sender.Text, false);
                        _ = Task.Run(ZazaGSMForm.AppSettings.FireSettingsSaving);
                    }
                    break;
                case nameof(inpDbName):
                    if (ZazaGSMForm.AppSettings.DbName != Sender.Text)
                    {
                        ZazaGSMForm.AppSettings.SetProperty(Settings.DbNameProperty, Sender.Text, false);
                        _ = Task.Run(ZazaGSMForm.AppSettings.FireSettingsSaving);
                    }
                    break;
                case nameof(inpUsrPassword):
                    if (ZazaGSMForm.AppSettings.UsrPassword != Sender.Text)
                    {
                        ZazaGSMForm.AppSettings.SetProperty(Settings.UsrPasswordProperty, Sender.Text, false);
                        _ = Task.Run(ZazaGSMForm.AppSettings.FireSettingsSaving);
                    }
                    break;
            }
        }
    }
}
