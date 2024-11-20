using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZazaGSM_Moblie.ViewModels;

namespace ZazaGSM_Moblie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IssuesPage : ContentPage
    {
        IssuesViewModel viewModel;

        private int deviceId;
        public int DeviceId
        {
            get => deviceId;
            set
            {
                SetSelectedDevice(value);
                deviceId = value;
            }
        }

        public IssuesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new IssuesViewModel();
            viewModel.Message += ViewModel_Message;
            viewModel.AskComplaint = AskComplaint;
        }

        private async Task<string> AskComplaint()
            => await DisplayPromptAsync("Új feladat", "panasz:", "OK", "Mégsem");

        private void ViewModel_Message(string title, string message)
            => DisplayAlert(title, message, "OK");

        public void SetSelectedDevice(int deviceId)
        {
            viewModel.SelectedDevice = Models.Collection.Devices.FirstOrDefault(device => device.KeyIsSame(deviceId));
        }
    }
}
