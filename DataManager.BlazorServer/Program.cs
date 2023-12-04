using DataManager.BlazorServer.Data;
using DataManager.Database.Data;
using System.Text;
using DataManager.Database.Utils;
using Newtonsoft.Json.Linq;
using BootstrapBlazor.Components;
using BlazorLearn;
using Microsoft.AspNetCore.Authentication.Cookies;

public class Program
{
    public static void Main(string[] args)
    {
        InitDb();

        var builder = WebApplication.CreateBuilder(args).Inject();

        builder.Services.AddAppAuthorization<AdminHandler>();

        // Add services to the container.
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddControllers().AddInject();

        builder.Services.AddBootstrapBlazor();
        builder.Services.AddSingleton<MessageService>();
        builder.Services.AddSingleton<WeatherForecastService>();
        // 增加 Table Excel 导出服务
        builder.Services.AddCsvExport();

        //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseHttpsRedirection();

        app.UseInject();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();
        //app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }

    private static void InitDb()
    {
        JObject obj=JsonUtils.LoadJson("DBConfig");
        SqliteDatabase sqliteDatabase = SqliteDatabase.GetInstance();
        string dbPath = obj["DbPath"].Value<string>();
        sqliteDatabase.Init(dbPath);
        sqliteDatabase.InitTableName(obj["TableDictionary"].Value<JArray>());
    }
}

