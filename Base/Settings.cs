using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZazaGsm.Base
{
    public class Settings
    {
        public const string DbAddressProperty = "DbAddress";
        public const string DbNameProperty = "DbName";
        public const string UsrNameProperty = "UsrName";
        public const string UsrPasswordProperty = "UsrPassword";

        public string DbAddress { get; private set; } = string.Empty;
        public string DbName { get; private set; } = string.Empty;
        public string UsrName { get; private set; } = string.Empty;
        public string UsrPassword { get; private set; } = string.Empty;

        public string ConnectionString =>
            $"Server={DbAddress};User ID={UsrName};Password={UsrPassword};Database={DbName}";

        /// <exception cref="ArgumentException"></exception>
        public void SetProperty(string propertyName, string value, bool needUIRefresh = true)
        {
            switch (propertyName)
            {
                case DbAddressProperty: DbAddress = value; break;
                case DbNameProperty: DbName = value; break;
                case UsrNameProperty: UsrName = value; break;
                case UsrPasswordProperty: UsrPassword = value; break;
                default:
                    throw new ArgumentException("Unknown property referenced: " + propertyName);
            }

            if (needUIRefresh)
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public delegate void SaveSettingsEventHandler();
        public event SaveSettingsEventHandler? SettingsSaving;

        public void FireSettingsSaving()
        {
            SettingsSaving?.Invoke();
        }
    }
}
