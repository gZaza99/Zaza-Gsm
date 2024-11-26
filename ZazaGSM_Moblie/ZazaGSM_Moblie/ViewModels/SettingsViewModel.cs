using System;
using System.Collections.Generic;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGSM_Moblie.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string DbAddress
        {
            get => App.AppSettings.DbAddress;
            set => App.AppSettings.SetProperty(nameof(Settings.DbAddress), value);
        }
        public string DbName
        {
            get => App.AppSettings.DbName;
            set => App.AppSettings.SetProperty(nameof(Settings.DbName), value);
        }
        public string UsrName
        {
            get => App.AppSettings.UsrName;
            set => App.AppSettings.SetProperty(nameof(Settings.UsrName), value);
        }
        public string UsrPassword
        {
            get => App.AppSettings.UsrPassword;
            set => App.AppSettings.SetProperty(nameof(Settings.UsrPassword), value);
        }
        /// <summary>Timeout in seconds.</summary>
        private int connectionTimeout;
        public int ConnectionTimeout
        {
            get => connectionTimeout;
            set => SetProperty(ref connectionTimeout, value, nameof(ConnectionTimeout));
        }

        public SettingsViewModel()
        {
            Title = "Beállítások";
            connectionTimeout = 15;
        }
    }
}
