using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;
using static ADM.Server.Model.Monitoring.MonitoringSearchView;

namespace ADM.Server.Model.Monitoring
{
    public class SearchTableRowItemView 
    {
        public int id { get; set; }

        public string name { get; set; }

        public string model { get; set; }
         
        public string status { get; set; }

        public TimeOnly on_schedule { get; set; }

        public TimeOnly off_schedule { get; set; }   

        public DateTime last_updated_time { get; set; }

        public DateTime last_respond_time { get; set; }

        public DateTime last_schedule_updated_at { get; set; }
    }
}
