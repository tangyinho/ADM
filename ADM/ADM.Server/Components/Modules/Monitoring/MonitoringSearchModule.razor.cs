using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using ADM.Server.Model.Monitoring; 

namespace ADM.Server.Components.Modules.Monitoring
{
    public partial class MonitoringSearchModule
    {
        [Parameter]
        [NotNull]
        public MonitoringSearchView? Value { get; set; }

        [Parameter]
        public EventCallback<MonitoringSearchView> ValueChanged { get; set; }

    }
}
