using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using ZazaGSM_Moblie.Models;

namespace ZazaGSM_Moblie.ViewModels
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        public delegate void ErrorHandler(string message);
        public event ErrorHandler ErrorMessage;

        private List<string> _issueStatuses;
        public List<string> IssueStatuses
        {
            get => _issueStatuses;
            private set => SetProperty(ref  _issueStatuses, value, nameof(IssueStatuses));
        }
        private Models.Issue selectedIssue;
        public Models.Issue SelectedIssue
        {
            get => selectedIssue;
            set => SetProperty(ref selectedIssue, value, nameof(SelectedIssue), OnSelectedIssueChanged);
        }
        private int? _quotation;
        public int? Quotation
        {
            get => _quotation;
            set => SetProperty(ref _quotation, value, nameof(Quotation));
        }
        private string _quotationCurrency;
        public string QuotationCurrency
        {
            get => _quotationCurrency;
            set => SetProperty(ref _quotationCurrency, value, nameof(QuotationCurrency));
        }
        private bool _isAccepted;
        public bool IsAccepted
        {
            get => _isAccepted;
            set => SetProperty(ref _isAccepted, value, nameof(IsAccepted));
        }
        private string _complaint;
        public string Complaint
        {
            get => _complaint;
            set => SetProperty(ref _complaint, value, nameof(Complaint));
        }
        private string _opinion;
        public string Opinion
        {
            get => _opinion;
            set => SetProperty(ref _opinion, value, nameof(Opinion));
        }
        private IssueStatus _status;
        public IssueStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value, nameof(Status));
        }
        private string _association;
        public string Association
        {
            get => _association;
            set => SetProperty(ref _association, value, nameof(Association));
        }
        private string _statusReason;
        public string StatusReason
        {
            get => _statusReason;
            set => SetProperty(ref _statusReason, value, nameof(StatusReason));
        }

        private bool _isPayed;
        public bool IsPayed
        {
            get => _isAccepted;
            set => SetProperty(ref _isPayed, value, nameof(IsPayed));
        }
        public IssueDetailsViewModel()
        {
            string[] names = Enum.GetNames(typeof(IssueStatus));
            IssueStatuses = names.ToList<string>();
            Title = Association;
        }

        public async void OnRefreshing(object sender, EventArgs e)
        {
            IsBusy = true;
            System.Diagnostics.Debug.WriteLine(sender.GetType());
            System.Diagnostics.Debug.WriteLine(e == EventArgs.Empty);
            IsBusy = false;
        }

        private void OnSelectedIssueChanged()
        {
            Title = SelectedIssue.Device.Association;
            Complaint = SelectedIssue.Complaint;
            Opinion = SelectedIssue.Opinion;
            Quotation = SelectedIssue.Quotation;
            QuotationCurrency = SelectedIssue.Currency;
            Association = SelectedIssue.Association;
            StatusReason = string.IsNullOrEmpty(SelectedIssue.StatusReason) ? "Ismeretlen" : SelectedIssue.StatusReason;
            Status = SelectedIssue.Status;
            IsAccepted = SelectedIssue.IsAccepted;
        }

        public void pickerStatus_Changed(object sender, EventArgs e)
        {
            Picker Sender = sender as Picker;
            IssueStatus newStatus = (IssueStatus)(Sender.SelectedIndex);
            if (newStatus == Status)
                return;

            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    SelectedIssue.Status = newStatus;
                    Models.Collection.SaveIssue(SelectedIssue);
                }
                catch (Exception ex)
                {
                    ErrorMessage.Invoke(ex.Message);
                }
            });
        }
    }
}
