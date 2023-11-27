using BootstrapBlazor.Components;

namespace DataManager.BlazorServer.Data
{
    public static class CsvExportServiceCollectionExtensions
    {
        /// <summary>
        /// 增加 BootstrapBlazor 服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCsvExport(this IServiceCollection services)
        {
            services.AddTransient<CsvExport>();
            return services;
        }
    }
}
