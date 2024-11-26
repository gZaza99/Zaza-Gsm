using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZazaGsm.Controller;
using ZazaGsm.Model;
using ZazaGsm.Base;

namespace ZazaGsm.View
{
    public partial class FilterView1 : UserControl, IResizable
    {
        public FilterView1()
        {
            InitializeComponent();
            ComboPropertyFilter.SelectedIndexChanged += (object? sender, EventArgs e) => CheckFiltering();
            ComboRelation.SelectedIndexChanged       += (object? sender, EventArgs e) => CheckFiltering();
            TxtbValue.TextChanged                    += (object? sender, EventArgs e) => CheckFiltering();
            CheckNegate.CheckedChanged               += (object? sender, EventArgs e) => CheckFiltering();
        }

        public Task OnResize(DrawableSizeEventArgs e)
        {
            TxtbValue.Size = new Size(Panel.ClientSize.Width - TxtbValue.Location.X - 5, TxtbValue.Size.Height);
            return Task.CompletedTask;
        }

        public void SetProperties(string[] properties)
        {
            ComboPropertyFilter.Items.Clear();
            foreach (string property in properties)
                ComboPropertyFilter.Items.Add(property);
            Properties = properties;
        }
        public string[] Properties { get; private set; }
        public string SelectedProperty => (string)ComboPropertyFilter.SelectedItem;
        public int SelectedPropertyIndex => (int)ComboPropertyFilter.SelectedIndex;
        public Relation SelectedRelation => Enum.Parse<Relation>(ComboPropertyFilter.SelectedText);
        public int SelectedRelationIndex => (int)ComboRelation.SelectedIndex;
        public string Value => TxtbValue.Text;
        public bool Negate => CheckNegate.Checked;
        public delegate ObservableCollection<TableRecord> FilterEventHandler(object sender, FilterEventArgs<TableRecord> e);
        public event FilterEventHandler Filter;
        public bool ReadyToFilter { get; private set; }
        public event EventHandler Ready;

        private void CheckFiltering()
        {
            if (SelectedProperty == null)
            {
                ReadyToFilter = false;
                return;
            }
            if (SelectedRelation == null)
            {
                ReadyToFilter = false;
                return;
            }
            if (string.IsNullOrEmpty(Value))
            {
                ReadyToFilter = false;
                return;
            }

            ReadyToFilter = true;
            Ready.Invoke(this, EventArgs.Empty);
            Filter.Invoke(this, new FilterEventArgs<TableRecord>(null, SelectedProperty, (Relation)SelectedRelationIndex, Value, Negate));
        }
    }
}
