using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZazaGSM_Moblie.ViewModels;

namespace ZazaGSM_Moblie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();
            viewModel.Message += ShowMessage;
            viewModel.AskType = AskType;
        }

        private async Task<string> AskType()
            => await DisplayPromptAsync("Új eszköz", "típus:", "OK", "Mégsem");

        private async void OnDeviceSelected(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            int dashIndex = Sender.Text.IndexOf('-');
            string id = Sender.Text.Substring(1, dashIndex - 2);

            viewModel.OnDeviceSelected(id);
        }

        private async void OnScannTapped(object sender, EventArgs e)
        {
            if (IsBusy)
                return;

            await viewModel.Scann();
        }

        protected override void OnAppearing()
            => viewModel.OnAppearing();

        private void ShowMessage(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() => DisplayAlert(title, message, "OK"));
        }
    }
}