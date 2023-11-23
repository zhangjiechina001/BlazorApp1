using DataManager.BlazorServer.Data;
using DataManager.Database.Data;
using System.Text;


public class Program
{
    public static void Main(string[] args)
    {
        SqliteDatabase sqliteDatabase = SqliteDatabase.GetInstance();
        string dbPath = "F:\\C#Project\\BlazorDataBoard\\DataManager.Database.Test\\bin\\Debug\\net6.0\\LIBSDataBase";
        sqliteDatabase.Init(dbPath);

        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddBootstrapBlazor();

        builder.Services.AddSingleton<WeatherForecastService>();

        // 增加 Table 数据服务操作类
        //builder.Services.AddTableDemoDataService();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}

