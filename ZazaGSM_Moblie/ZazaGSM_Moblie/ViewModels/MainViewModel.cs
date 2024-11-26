using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZazaGSM_Moblie.Models;
using MySqlConnector;
using System.Data.Common;
using System.Diagnostics;
using ZXing.Net.Mobile.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using ZazaGSM_Moblie.Views;
using System.IO;
using ZazaGsm.Base;

namespace ZazaGSM_Moblie.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public delegate void MessageHandler(string title, string message);
        public event MessageHandler Message;
        public Func<Task<string>> AskType;
        public ObservableCollection<Device> Items { get; }
        public Xamarin.Forms.Command AddCommand { get; }
        public Xamarin.Forms.Command RefreshCommand { get; }
        public MainViewModel()
        {
            Title = "ZazaGSM Mobil";
            
            //AddCommand = new Xamarin.Forms.Command(OnAddDevice);
            //RefreshCommand = new Xamarin.Forms.Command(OnRefresh);
        }

        public async void OnAddDevice()
        {
            string deviceType = await AskType.Invoke();
            if (string.IsNullOrEmpty(deviceType))
                return;

            Device newDevice = new Device()
            {
                Type = deviceType,
            };
            bool success;
            try
            {
                success = Models.Collection.SaveDevice(newDevice);
            }
            catch (Exception ex)
            {
                Message.Invoke("Mentési hiba", ex.Message);
                return;
            }
            if (success)
                Message.Invoke("Mentés visszajelzés", "Sikeres mentés");
            else
                Message.Invoke("Mentés visszajelzés", "Nem sikerült a mentés");
        }

        public async Task Scann()
        {
            var scanPage = new ZXingScannerPage();
            // Navigate to our scanner page
            await AppShell.Current.Navigation.PushAsync(scanPage);
            Device searchDevice = new Device();
            searchDevice.Scanned += OnDeviceScanned;

            scanPage.OnScanResult += (result) =>
            {
                Xamarin.Forms.DependencyService.Get<ISoundPlayer>().Play("beep_1.mp3");
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    await AppShell.Current.Navigation.PopAsync();
                    if (!string.IsNullOrEmpty(result.Text))
                        searchDevice.Barcode = result.Text;
                });
            };
        }

        public void OnRefresh()
        {
            Task.Run(() =>
            {
                try
                {
                    Models.Collection.LoadDevices();
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

        public void OnDeviceSelected(string id)
        {
            if (IsBusy)
                return;

            IssuesPage page = new IssuesPage() { DeviceId = int.Parse(id) };
            AppShell.Current.Navigation.PushAsync(page);
        }

        private async void OnDeviceScanned(ZazaGsm.Base.Device device)
        {
            Device searchedDevice = Devices.FirstOrDefault(currentDevice => currentDevice.Barcode == device.Barcode);
            if (searchedDevice == null)
            {
                Xamarin.Forms.DependencyService.Get<ISoundPlayer>().Play("beep_2.mp3");

                Message.Invoke("Keresési hiba", "Eszköz nem található");
                return;
            }
            else
            {
                IssuesPage page = new IssuesPage() { DeviceId = (int)searchedDevice.TableKey.Id };
                await AppShell.Current.Navigation.PushAsync(page);
            }
        }

        public void OnAppearing()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Task.Run(() =>
            {
                try
                {
                    Models.Collection.LoadDevices();
                }
                catch (Exception ex)
                {
                    Message?.Invoke("Betöltési hiba", ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
