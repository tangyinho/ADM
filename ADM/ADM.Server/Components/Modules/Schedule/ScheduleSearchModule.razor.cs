using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using ADM.Server.Model.Schedule;

namespace ADM.Server.Components.Modules.Schedule
{
    public partial class ScheduleSearchModule
    {  
        [Parameter]
        [NotNull]
        public ScheduleSearchView? Value { get; set; }

        [Parameter]
        public EventCallback<ScheduleSearchView> ValueChanged { get; set; }

    }
}
