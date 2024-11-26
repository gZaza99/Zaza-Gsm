using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ZazaGsm.Base;

namespace ZazaGSM_Moblie.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; } = Models.Collection.Customers;
        public ObservableCollection<Invoice> Invoices { get; } = Models.Collection.Invoices;
        public ObservableCollection<Device> Devices { get; } = Models.Collection.Devices;
        public ObservableCollection<Issue> Issues { get; } = Models.Collection.Issues;

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
