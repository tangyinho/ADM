using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;

namespace ADM.Server.Model.Schedule
{
    public class SearchTableRowItemView
    {
        public int id { get; set; } 
        public string name { get; set; } 
        public DateTime schedule_start { get; set; }
        public DateTime schedule_end { get; set; }
        public EnumStatus status { get; set; }
    }

    public enum EnumStatus
    {
        [Display(Name = "Active")]
        active,

        [Display(Name = "In-Active")]
        inactive,
    }
}
