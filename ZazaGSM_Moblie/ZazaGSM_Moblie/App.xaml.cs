using Xamarin.Forms;
using ZazaGSM_Moblie.Models;

namespace ZazaGSM_Moblie
{
    public partial class App : Application
    {
        public static Settings AppSettings { get; } = new Settings("Zaza-Laptop", "zaza_gsm", "ClientUser", "ClientUser12");
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
