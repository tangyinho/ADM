using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json; 
using ADM.Server.Data;
using ADM.Server.Model.Monitoring;
using ADM.Server.Service;

namespace ADM.Server.Components.Pages
{
    public partial class Monitoring : ComponentBase
    {
        [Inject]
        [NotNull]
        private IStringLocalizer<Foo>? Localizer { get; set; }

        //private readonly ConcurrentDictionary<Foo, IEnumerable<SelectedItem>> _cache = new();

        private static IEnumerable<int> PageItemsSource => new int[] { 20 ,30 };

        [NotNull]
        private List<SearchTableRowItemView>? Items { get; set; } = new List<SearchTableRowItemView> { };

        [NotNull]
        private ToastContainer? ToastContainer { get; set; }

        [CascadingParameter]
        [NotNull]
        private BootstrapBlazorRoot? Root { get; set; }

        private Table<SearchTableRowItemView> tableRef;

        private ITableSearchModel CustomerSearchModel { get; set; } = new MonitoringSearchView();

        private APIService apiService { get; set; } = new APIService(new HttpClient());

        private string testJson { get; set; } = string.Empty;

        public Modal? modal { get; set; } = new Modal();

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            apiService = new APIService(new HttpClient());
            ToastContainer = Root.ToastContainer;
            await getEquipmentStatus();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private async Task getEquipmentStatus()
        { 
            try
            {
                var filePath = Path.Combine(Env.WebRootPath, "json", "data.json");

                if (System.IO.File.Exists(filePath))
                {
                    testJson = await System.IO.File.ReadAllTextAsync(filePath);
                }

                if (testJson is not null && !string.IsNullOrEmpty(testJson))
                {
                    var equipmentTmp = JsonSerializer.Deserialize<List<ViewEquipment>>(testJson);

                    Items = equipmentTmp.Select(x => new SearchTableRowItemView()
                    {
                        id = x.id,
                        model = x.model,
                        nornormal_schedule_on = x.normal_schedule_on,
                        normal_schedule_off = x.normal_schedule_off,
                        next_poweron_schedule = DateTime.Now.AddDays(0.5),
                        next_poweroff_schedule = DateTime.Now.AddDays(1),
                        last_updated_time = DateTime.Now.AddDays(-1),
                        last_respond_time = DateTime.Now.AddDays(-2),
                        

                    }).ToList().OrderBy(x => x.id).ToList();

                    tableRef?.QueryAsync();
                    await InvokeAsync(StateHasChanged); 
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        private async Task<bool> OnSearch()
        { 
            await tableRef.QueryAsync();
            return true;
        }

        private async Task<bool> OnReset()
        {
            CustomerSearchModel.Reset();
            await OnSearch();
            return true;
        }
        private Task<QueryData<SearchTableRowItemView>> OnSearchModelQueryAsync(QueryPageOptions options)
        {
            var items =Items;
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName)){
                isSorted = true;
            }
             
            return Task.FromResult(new QueryData<SearchTableRowItemView>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = items.Count(),
                IsFiltered = true,
                IsSorted = isSorted,
                IsSearch = true
            });
        }

        private void Dispose()
        {
            // Clean up the timer when the component is disposed
        }
    }

}
