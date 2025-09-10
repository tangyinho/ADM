using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using System.Linq;
using System.Security.Claims;

using ADM.Server.Data;
using ADM.Server.Helpers;
using ADM.Server.Service;

namespace ADM.Server.Components.Shared
{
    public partial class MainLayout
    {
        private bool UseTabSet { get; set; } = false;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; } = false;

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = false;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized(); 
            Menus = await GetIconSideMenuItems();
        }

        private async Task<List<MenuItem>> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new() { Text = "Index", Icon = "fa-solid fa-fw fa-house", Url = "/" , Match = NavLinkMatch.All,},
                new() { Text = "Schedule", Icon = "fa-solid fa-fw fa-calendar", Url = "/schedule", }
            };

            return menus;
        }

        private void GoToLoginPage()
        {
            navigationManager.NavigateTo("/login", true);
        }

        private void GoToLogoutPage()
        {
            navigationManager.NavigateTo("/logout", true);
        }
    }
}
