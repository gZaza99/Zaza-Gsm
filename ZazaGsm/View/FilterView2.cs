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

namespace ZazaGsm.View
{
    public partial class FilterView2 : UserControl
    {
        public FilterView2()
        {
            InitializeComponent();
        }

        public ComboBox ComboPropFilter => ComboPropertyFilter;
        public string SelectedProperty => ComboPropertyFilter.SelectedText;
        public int SelectedPropertyIndex => (int)ComboPropertyFilter.SelectedIndex;
        public Relation SelectedRelation => Enum.Parse<Relation>(ComboPropertyFilter.SelectedText);
        public int SelectedRelationIndex => (int)ComboRelation.SelectedIndex;
        public string Value => TxtbValue.Text;
        public bool Negate => CheckNegate.Checked;
        public void SetSelectedPropChanged(EventHandler eventHandler)
        {
            ComboPropertyFilter.SelectedIndexChanged += eventHandler;
        }
        public void SetSelectedRelationChanged(EventHandler eventHandler)
        {
            ComboRelation.SelectedIndexChanged += eventHandler;
        }
    }
}
