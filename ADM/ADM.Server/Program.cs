using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text;

using ADM.Server.Components;
using ADM.Server.Helpers;
using ADM.Server.Service;

//DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor(options=> {
    options.ToastDelay = 5000;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
});

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication()
        .AddCookie(options => { options.LoginPath = "/login"; });

// 增加 Pdf 导出服务
builder.Services.AddBootstrapBlazorTableExportService();

// 增加 Html2Pdf 服务
builder.Services.AddBootstrapBlazorHtml2PdfService();

// 增加 SignalR 服务数据传输大小限制配置
builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);

//builder.Services.AddDbContext<c8765Context>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ProtectedSessionStorage>();

//builder.Services.AddScoped<AuthUserService>();

//builder.Services.AddScoped<WTIServerAuthenticationStateProvider>();

//builder.Services.AddScoped<AuthenticationStateProvider>(sp
//    => sp.GetRequiredService<WTIServerAuthenticationStateProvider>());

//builder.Services.AddSingleton<DatabaseHelper>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication(); 
app.UseAuthorization(); 
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
