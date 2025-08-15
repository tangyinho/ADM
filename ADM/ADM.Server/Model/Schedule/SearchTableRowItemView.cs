using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;

namespace ADM.Server.Model.Schedule
{
    public class SearchTableRowItemView
    {
        public int id { get; set; } // Can be ignored on create page
        public string name { get; set; } 
        public DateTime schedule_start { get; set; }
        public DateTime schedule_end { get; set; }
        public bool active { get; set; } 
    }
}
