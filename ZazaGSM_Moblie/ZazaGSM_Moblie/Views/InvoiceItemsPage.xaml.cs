using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZazaGSM_Moblie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceItemsPage : ContentPage
    {
        public int InvoiceId { get; set; }
        public InvoiceItemsPage()
        {
            InitializeComponent();
        }
    }
}