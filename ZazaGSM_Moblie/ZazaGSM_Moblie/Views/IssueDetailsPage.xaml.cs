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
	public partial class IssueDetailsPage : ContentPage
	{
		public Models.Issue? SelectedIssue
		{
			get => viewModel.SelectedIssue;
			set => viewModel.SelectedIssue = value;
		}

		IssueDetailsViewModel viewModel;

		/// <summary>Only for Binding</summary>
		public IssueDetailsPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new IssueDetailsViewModel();
			refreshView.Refreshing += viewModel.OnRefreshing;
        }
        public IssueDetailsPage(Models.Issue selectedIssue)
        {
            InitializeComponent();
            BindingContext = viewModel = new IssueDetailsViewModel();
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            refreshView.Refreshing += viewModel.OnRefreshing;
            SelectedIssue = selectedIssue;
            pickerStatus.SelectedIndexChanged += PickerStatus_SelectedIndexChanged;
            viewModel.ErrorMessage += ViewModel_ErrorMessage;
        }

        private void ViewModel_ErrorMessage(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Mentési hiba", message, "Ok");
            });
        }

        private void PickerStatus_SelectedIndexChanged(object sender, EventArgs e)
            => viewModel.pickerStatus_Changed(sender, e);

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.Status))
			{
				pickerStatus.SelectedIndex = (int)viewModel.Status;
			}
        }
    }
}