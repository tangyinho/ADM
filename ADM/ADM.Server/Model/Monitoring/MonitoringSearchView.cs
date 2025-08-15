using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;

namespace ADM.Server.Model.Monitoring
{
    public class MonitoringSearchView : ITableSearchModel
    {
        public string? name { get; set; }
        public EnumStatus? status { get; set; } = null;

        public IEnumerable<IFilterAction> GetSearches()
        {
            var ret = new List<IFilterAction>();

            //if (!string.IsNullOrEmpty(name))
            //{
            //    ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.name), name, FilterAction.Contains));
            //}

            //if (status != null)
            //{
            //    ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.status), status, FilterAction.Equal));
            //}

            //if (isConnected != null)
            //{
            //    ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.isConnected), isConnected, FilterAction.Equal));
            //}

            //if (station != null)
            //{
            //    ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.station), station.ToString, FilterAction.Equal));
            //}

            //if (!string.IsNullOrEmpty(location))
            //{
            //    ret.Add(new SearchFilterAction(nameof(SearchTableRowItemView.platform), location, FilterAction.Contains));
            //}

            return ret;
        }

        public void Reset()
        {
            name = null;
            status = null;  
        } 
    }

    public enum EnumStatus
    {
        [Display(Name = "ON")]
        ON,

        [Display(Name = "OFF")]
        OFF
    }

    //public enum EnumStation
    //{
    //    [Display(Name = "YAT")]
    //    YAT,

    //    [Display(Name = "MOK")]
    //    MOK,

    //    [Display(Name = "NOP")]
    //    NOP,

    //    [Display(Name = "PRE")]
    //    PRE,

    //    [Display(Name = "TAW")]
    //    TAW,

    //    [Display(Name = "KOT")]
    //    KOT,
    //}


}
