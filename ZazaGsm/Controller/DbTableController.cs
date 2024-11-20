using System.Collections.ObjectModel;
using ZazaGsm.Model;

namespace ZazaGsm.Controller
{
    public abstract class DbTableController<T> : DatabaseController<T> where T : TableRecord
    {
        public override bool IsRecordChanged(T record)
        {
            return base.IsRecordChanged(record);
        }

        public override bool SaveRecord(T record)
        {
            return base.SaveRecord(record);
        }

        protected ObservableCollection<Issue>? Where(string property, object value, bool negate = false)
        {
            ObservableCollection<Issue>? filtered = null;
            if (property == nameof(Issue.Key) || property == nameof(Issue.TableKey))
            {
                filtered = new ObservableCollection<Issue>();
                foreach (Issue issue in Issues.GetAll())
                {
                    bool matches = negate ? issue.TableKey != (TableRecordKey)value : issue.TableKey == (TableRecordKey)value;
                    if (matches)
                        filtered.Add(issue);
                }
            }
            return filtered;
        }
    }
}
