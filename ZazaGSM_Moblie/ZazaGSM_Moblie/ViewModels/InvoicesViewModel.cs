using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZazaGSM_Moblie.Views;

namespace ZazaGSM_Moblie.ViewModels
{
    public class InvoicesViewModel : BaseViewModel
    {
        public delegate void MessageHandler(string title, string message);
        public event MessageHandler Message;
        public Func<Task<string>> AskCustomer;
        public Command AddCommand { get; }
        public Command RefreshCommand { get; }
        public InvoicesViewModel()
        {
            Title = "Invoices";
            AddCommand = new Command(OnAddInvoice);
            RefreshCommand = new Command(OnRefreshing);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnAddInvoice()
        {
            Message.Invoke("Add invoice", "Add invoice have been tapped.");
            /*string customername = await AskCustomer();
            Task.Run(() =>
            {
                try
                {
                    lock(Models.Collection.Invoices)
                    {
                        IsBusy = true;

                        Models.Collection.AddInvoice();
                    }
                }
                catch (Exception ex)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                        Message?.Invoke("Mentési hiba", ex.Message);
                    });
                }
                finally
                {
                    IsBusy = false;
                }
            });*/
        }

        private void OnRefreshing()
        {
            Task.Run(() =>
            {
                try
                {
                    Models.Collection.LoadCustomers();
                    Models.Collection.LoadInvoices();
                }
                catch (Exception ex)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                        Message?.Invoke("Betöltési hiba", ex.Message);
                    });
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        public void OnInvoiceSelected(string id)
        {
            if (IsBusy)
                return;

            Message.Invoke("Tap", $"Inovice (#{id}) tapped");
            //InvoiceItemsPage page = new InvoiceItemsPage() { InvoiceId = int.Parse(id) };
            //AppShell.Current.Navigation.PushAsync(page);
        }
    }
}
