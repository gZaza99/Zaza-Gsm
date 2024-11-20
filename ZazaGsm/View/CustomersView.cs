using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZazaGsm.Controller;
using ZazaGsm.Model;

namespace ZazaGsm.View
{
    public partial class CustomersView : UserControl, IResizable
    {
        public CtrlCustomer Controller { get; private set; }

        public CustomersView()
        {
            InitializeComponent();
            Controller = new CtrlCustomer();
            FilterView.SetProperties(new string[4] { "Id", "Név", "Vonlakód", "Tartozás" });
        }

        private Task AddCustomers(BaseDataStore<Customer> customersToAdd)
        {
            if (Grid.InvokeRequired)
            {
                Grid.Invoke(AddCustomers, customersToAdd);
                return Task.CompletedTask;
            }
            Customer customer;
            for (int index = 0; index < customersToAdd.Count; index++)
            {
                customer = customersToAdd[index];
                DataGridViewRow currentRow = new();
                currentRow.HeaderCell.Value = customer.TableKey.Id.ToString();
                DataGridViewCell nameCell = new DataGridViewTextBoxCell
                {
                    ValueType = typeof(string),
                    Value = customer.Name,
                };
                currentRow.Cells.Add(nameCell);
                Grid.Rows.Add(currentRow);
            }

            return Task.CompletedTask;
        }

        public Task Clear()
        {
            if (Grid.InvokeRequired)
                Grid.Invoke(Grid.Rows.Clear);
            else
                Grid.Rows.Clear();
            return Task.CompletedTask;
        }

        public void TryRefresh(bool forceRefresh = true)
        {
            if (forceRefresh)
                Controller.LoadData();
            Clear();
            AddCustomers(Collection.CustomerDataStore);
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            FilterView.OnResize(e);
            return Task.CompletedTask;
        }
    }
}
