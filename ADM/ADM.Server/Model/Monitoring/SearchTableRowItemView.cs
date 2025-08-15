using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;
using static ADM.Server.Model.Monitoring.MonitoringSearchView;

namespace ADM.Server.Model.Monitoring
{
    public class SearchTableRowItemView 
    {
        public int id { get; set; }

        public string model { get; set; }
         
        public string status { get; set; }

        public TimeOnly nornormal_schedule_on { get; set; }

        public TimeOnly normal_schedule_off { get; set; }   

        public DateTime next_poweroff_schedule { get; set; }

        public DateTime next_poweron_schedule { get; set; }

        public DateTime last_updated_time { get; set; }

        public DateTime last_respond_time { get; set; }
    }
}
