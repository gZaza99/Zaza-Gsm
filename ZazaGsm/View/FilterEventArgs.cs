using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Controller;

namespace ZazaGsm.View
{
    public class FilterEventArgs<T> : EventArgs
    {
        public FilterEventArgs(List<T> unfilteredList, string property, Relation relation, string value, bool negate)
        {
            UnfilteredList = unfilteredList;
            FilteredList = null;
            Property = property;
            Relation = relation;
            Value = value;
            Negate = negate;
        }
        public ObservableCollection<T>? FilteredList { get; private set; }
        public List<T> UnfilteredList { get; private set; }
        public string Property { get; private set; }
        public Relation Relation { get; private set; }
        public string Value { get; private set; }
        public bool Negate { get; private set; }
    }
}
