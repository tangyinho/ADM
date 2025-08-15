using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.Entity;
using System.Text.Json;
using ADM.Server.Components.Modules;
using ADM.Server.Data;
using ADM.Server.Helpers; 
using ADM.Server.Model.Schedule;

namespace ADM.Server.Components.Pages
{
    public partial class Schedule
    {
        private SearchMode SearchModeValue { get; set; }
        private ITableSearchModel CustomerSearchModel { get; set; } = new ScheduleSearchView();
        private List<SearchTableRowItemView>? Items { get; set; } = new List<SearchTableRowItemView>();
        private List<SearchTableRowItemView> SelectedRows = new List<SearchTableRowItemView>();
        private Table<SearchTableRowItemView> tableRef = null;

        public Modal? modal { get; set; } = new Modal();
        private string modalTitle { get; set; } = "";
        private string modalMessage { get; set; } = "";
        private CretaeRequestView createRequest { get; set; } = new CretaeRequestView();
        private string SortString { get; set; } 
        private CheckboxState checkboxState { get; set; } = CheckboxState.UnChecked;
        private string testJson { get; set; } = string.Empty;       
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized(); 
            await OnSearch(); 
        }

        /** Action **/
        private async Task LoadDataBaseRecords()
        {
            try
            {
                var filePath = Path.Combine(Env.WebRootPath, "json", "schedule.json");

                if (System.IO.File.Exists(filePath))
                {
                    testJson = await System.IO.File.ReadAllTextAsync(filePath);
                }

                if (testJson is not null && !string.IsNullOrEmpty(testJson))
                {
                    Items = JsonSerializer.Deserialize<List<SearchTableRowItemView>>(testJson);
                    await tableRef?.QueryAsync(); 
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        private async Task OnSearch()
        { 
            await LoadDataBaseRecords(); 
        }

        private async Task OnReset()
        {
            CustomerSearchModel.Reset();
            await OnSearch();
        }
 
        /** fetch the table data **/
        private Task<QueryData<SearchTableRowItemView>> OnSearchModelQueryAsync(QueryPageOptions options)
        {
            IEnumerable<SearchTableRowItemView> items = Items;
            var total = items.Count();
            var pagetotal = items.Count() / options.PageItems;

            if ((items.Count() % options.PageItems) > 0)
            {
                pagetotal++;
            }

            if (pagetotal < options.PageIndex)
            {
                options.PageIndex = 1;
            }

            items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList();

            return Task.FromResult(new QueryData<SearchTableRowItemView>()
            {
                Items = items,
                TotalCount = total,
                IsSorted = true,
                IsFiltered = options.Filters.Any(),
                IsSearch = options.Searches.Any(),
                IsAdvanceSearch = options.AdvanceSearches.Any()
            });
        }
    }
}

