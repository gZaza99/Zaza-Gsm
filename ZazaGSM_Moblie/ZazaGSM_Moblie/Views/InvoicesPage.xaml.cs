using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZazaGSM_Moblie.ViewModels;

namespace ZazaGSM_Moblie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoicesPage : ContentPage
    {
        private readonly InvoicesViewModel viewModel;
        public InvoicesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new InvoicesViewModel();
            viewModel.Message += ShowMessage;
            viewModel.AskCustomer += AskCustomer;
        }

        private Task<string> AskCustomer()
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing() => viewModel.OnAppearing();
        private void ShowMessage(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() => DisplayAlert(title, message, "OK"));
        }

        private void OnInvoiceSelected(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            int closeBracketIndex = Sender.Text.IndexOf(')');
            string id = Sender.Text.Substring(2, closeBracketIndex - 2);

            viewModel.OnInvoiceSelected(id);
        }
    }
}