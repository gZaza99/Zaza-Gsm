using Xamarin.Forms;
using ZazaGSM_Moblie.Models;
using ZazaGsm.Base;

namespace ZazaGSM_Moblie
{
    public partial class App : Application
    {
        public static Settings AppSettings { get; } = new Settings();
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            AppSettings.SetProperty(nameof(Settings.DbAddress), "Zaza-Laptop");
            AppSettings.SetProperty(nameof(Settings.DbName), "zaza-gsm");
            AppSettings.SetProperty(nameof(Settings.UsrName), "ClientUser");
            AppSettings.SetProperty(nameof(Settings.UsrPassword), "ClientUser12");
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
