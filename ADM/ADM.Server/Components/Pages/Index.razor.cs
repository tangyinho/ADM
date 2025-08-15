using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;


namespace ADM.Server.Components.Pages
{
    public partial class Index
    {
        private Random Randomer { get; set; } = new Random();
        private IStringLocalizer<Index>? Localizer { get; set; }
        private string serverJson { get; set; } = string.Empty;
        public string chartSize { get; set; } = "270px"; 
        private System.Timers.Timer? _timer;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();  
        }
        protected override async Task OnAfterRenderAsync(bool firstRender) {
            await base.OnAfterRenderAsync(firstRender); 
        }
    }
}
