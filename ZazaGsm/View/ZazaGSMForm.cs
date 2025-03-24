using MySqlConnector;
using System.Configuration;
using System.Diagnostics;
using ZazaGsm.Controller;
using ZazaGsm.Model;
using ZazaGsm.View;
using ZazaGsm.Base;

namespace ZazaGsm
{
    public partial class ZazaGSMForm : Form
    {
        private Type CurrentPage;

        private readonly SettingsView settingsPage;
        private readonly CustomersView customersPage;
        private readonly DevicesView devicesPage;
        private readonly IssuesView issuesPage;
        private readonly InvoicesView invoicesPage;

        public static Settings AppSettings = new();

        private void SetCurrentPage(UserControl currentPage)
        {
            currentPage.BringToFront();
            CurrentPage = currentPage.GetType();
        }

        public ZazaGSMForm()
        {
            InitializeComponent();

            settingsPage = new SettingsView();
            customersPage = new CustomersView();
            devicesPage = new DevicesView();
            issuesPage = new IssuesView();
            invoicesPage = new InvoicesView();
            CurrentPage = typeof(SettingsView);

            issuesPage.ShowMessage += ShowMessage;

            ErrorHandler.ShowError = this.ShowError;

            PostInitilalization();

            _ = Task.Run(settingsPage.TryLoadSettings).ContinueWith(task =>
            {
                if (task.Result == true)
                {
                    TryRefreshAllViews();
                    //TryLoadAllData();
                }
            });
        }

        private void TryLoadAllData()
        {
            try
            {
                customersPage.Controller.LoadData();
                customersPage.TryRefresh(false);
                devicesPage.Controller.LoadData();
                devicesPage.TryRefresh(false);
                issuesPage.Controller.LoadData();
                issuesPage.TryRefresh(false);

                invoicesPage.TryRefresh();
            }
            catch (MySqlException ex)
            {
                ErrorHandler.ErrorMessage = "Nem sikerült csatlakozni az adatbázishoz.";
                ErrorHandler.Exception = ex;
                ErrorHandler.ErrorCode = ErrorHandler.Code.ConnectionFailure;
                return;
            }
        }

        private void TryRefreshAllViews()
        {
            try
            {
                // Loading order is important!
                customersPage.TryRefresh();
                devicesPage.TryRefresh();
                issuesPage.TryRefresh();
                invoicesPage.TryRefresh();
            }
            catch (MySqlException ex)
            {
                ErrorHandler.ErrorMessage = "Nem sikerült csatlakozni az adatbázishoz.";
                ErrorHandler.Exception = ex;
                ErrorHandler.ErrorCode = ErrorHandler.Code.ConnectionFailure;
                return;
            }
        }

        private void ShowError()
        {
            if (this.InvokeRequired)
                this.Invoke(ShowError);
            else
            {
                if (ErrorHandler.ErrorMessage == null)
                    throw new Exception($"An error occurred in {nameof(ErrorHandler)}, but {nameof(ErrorHandler)}.{nameof(ErrorHandler.ErrorMessage)} not filled.");

                string text = ErrorHandler.ErrorMessage;
                if (ErrorHandler.Exception != null)
                    text += "\n" + ErrorHandler.Exception.Message;
                MessageBox.Show(text, ErrorHandler.Title ?? string.Empty);
            }
        }

        private void PostInitilalization()
        {
            mainPanel.Controls.Add(settingsPage);
            settingsPage.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(devicesPage);
            devicesPage.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(customersPage);
            customersPage.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(issuesPage);
            issuesPage.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(invoicesPage);
            invoicesPage.Dock = DockStyle.Fill;

            OnResize(this, EventArgs.Empty);
            SetCurrentPage(settingsPage);
        }

        public void SwitchPageTo(Type pageType)
        {
            /**/
            if (pageType == typeof(SettingsView))
                SetCurrentPage(settingsPage);
            else if (pageType == typeof(CustomersView))
                SetCurrentPage(customersPage);
            else if (pageType == typeof(DevicesView))
                SetCurrentPage(devicesPage);
            else if (pageType == typeof(IssuesView))
                SetCurrentPage(issuesPage);
            else if (pageType == typeof(InvoicesView))
                SetCurrentPage(invoicesPage);
        }

        private void OnResize(object sender, EventArgs e)
        {
            Debug.WriteLine(Size);
            var args = new DrawableSizeEventArgs(mainPanel.ClientSize, mainPanel.Padding.Horizontal);

            _ = navigationPanel.OnResize(new DrawableSizeEventArgs(navPanel.ClientSize, navPanel.Padding.Horizontal));
            _ = issuesPage.OnResize(args);
            _ = invoicesPage.OnResize(args);
            _ = customersPage.OnResize(args);
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            _ = Task.Run(settingsPage.TryLoadSettings).ContinueWith(
                task => { TryRefreshAllViews(); } );
        }

        private void BtnReload_MouseEnter(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(btnReload, "Újratöltés");
        }

        private void BtnReload_MouseLeave(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(btnReload, "null");
        }

        public void ShowMessage(string message, bool IsError)
        {
            if (IsError)
            {

            }
            else
            {

            }
        }
    }
}