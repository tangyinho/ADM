using BootstrapBlazor.Components; 
namespace ADM.Server.Model.Schedule
{
    public class ScheduleSearchView : ITableSearchModel
    {
        public EnumStatus? status { get; set; }
        public string? subject { get; set; }
        public DateTime? searchStartDate { get; set; }

        public IEnumerable<IFilterAction> GetSearches()
        {
            var ret = new List<IFilterAction>();

            if (status != null)
            {
                ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.id), status, FilterAction.Equal));
            }

            if (!string.IsNullOrEmpty(subject))
            {
                ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.name), subject, FilterAction.Contains));
            }

            if (searchStartDate != null)
            {
                ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.schedule_start), searchStartDate, FilterAction.GreaterThanOrEqual));
            }
            return ret;
        }

        public SearchFilter GetSearchFilter() {
            return new SearchFilter()
            {
                status = status,
                subject = subject,
                searchStartDate = searchStartDate
            };
        }

        public void Reset()
        {
            status = null;
            subject = null;
            searchStartDate = null;
        }
    }

    public class SearchFilter()
    {
        public EnumStatus? status { get; set; }
        public string? subject { get; set; }
        public DateTime? searchStartDate { get; set; }
    }

}
