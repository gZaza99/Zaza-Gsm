using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZazaGSM_Moblie.Models;
using ZazaGSM_Moblie.Views;

namespace ZazaGSM_Moblie.ViewModels
{
    public class IssuesViewModel : BaseViewModel
    {
        public ObservableCollection<Issue> ContainerItems { get; }
        public delegate void MessageHandler(string title, string message);
        public event MessageHandler Message;
        public Func<Task<string>> AskComplaint;
        public Xamarin.Forms.Command AddCommand { get; }
        private Device selectedDevice;
        public Device SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                _ = Task.Run(() =>
                {
                    try
                    {
                        Collection.LoadIssues();
                    }
                    catch (Exception ex)
                    {
                        Message.Invoke("Betöltési hiba", ex.Message);
                    }
                }).ContinueWith(t =>
                {
                    IEnumerable<Issue> items = Issues.Where(issue => issue.Device.KeyIsSame(value));
                    int count = items.Count();
                    for (int i = 0; i < items.Count(); i++)
                        ContainerItems.Add(items.ElementAt(i));
                });
                Title = SelectedDevice.Type;
            }
        }
        public Xamarin.Forms.Command<Issue> IssueTapCommand { get; set; }
        public Xamarin.Forms.Command RefreshCommand { get; }

        public IssuesViewModel()
        {
            ContainerItems = new ObservableCollection<Issue>();
            IssueTapCommand = new Xamarin.Forms.Command<Issue>(OnIssueTapped);
            AddCommand = new Xamarin.Forms.Command(OnAddTapped);
            RefreshCommand = new Xamarin.Forms.Command(OnRefreshing);
        }

        private void OnRefreshing()
        {
            Task.Run(() =>
            {
                try
                {
                    Models.Collection.LoadIssues();
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

        private async void OnAddTapped()
        {
            string complaint = await AskComplaint.Invoke();
            if (string.IsNullOrEmpty(complaint))
                return;
            Issue newIssue = new Issue()
            {
                Complaint = complaint,
                Device = SelectedDevice
            };
            bool success = Collection.SaveIssue(newIssue);
            if (success)
                Message.Invoke("Mentés visszajelzés", "Sikeres mentés");
            else
                Message.Invoke("Mentés visszajelzés", "Nem sikerült a mentés");
        }

        private async void OnIssueTapped(Issue issue)
        {
            IssueDetailsPage page = new IssueDetailsPage(issue);
            await AppShell.Current.Navigation.PushAsync(page);
        }
    }
}
