using BootstrapBlazor.Components;
using MiniExcelLibs;
using System.Collections.Generic;
using System.Data;

namespace DataManager.BlazorServer.Data
{
    class CsvExport
    {
        private IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceProvider"></param>
        public CsvExport(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
     
        public async Task<bool> ExportAsync(string[,] table, ExcelType excelType, string? fileName = null)
        {
            var value = new List<Dictionary<string, object?>>();
            int rowCount=table.GetLength(0);
            for(int i=1; i<rowCount; i++)
            {
                var dic=ConvertToDictionary(GetRow(table,0),GetRow(table,i));
                value.Add(dic);
            }
            using var stream = new MemoryStream();
            await MiniExcel.SaveAsAsync(stream, value, excelType: excelType);

            fileName ??= $"ExportData_{DateTime.Now:yyyyMMddHHmmss}.{GetExtension()}";
            stream.Position = 0;
            var downloadService = ServiceProvider.GetRequiredService<DownloadService>();
            await downloadService.DownloadFromStreamAsync(fileName, stream);
            return true;

            string GetExtension() => excelType == ExcelType.XLSX ? "xlsx" : "csv";
        }

        private Dictionary<string,object?> ConvertToDictionary(string[] key, string[] val)
        {
            Dictionary<string,object?> result=new Dictionary<string,object?>();
            for (int i = 0; i < key.Length; i++)
            {
                result.Add(key[i], val[i]);
            }
            return result;
        }

        private string[] GetRow(string[,] array, int rowIndex)
        {
            int colCount = array.GetLength(1);

            // 创建字符串数组以保存行数据
            string[] rowData = new string[colCount];

            // 复制指定行的数据到新数组
            for (int col = 0; col < colCount; col++)
            {
                rowData[col] = array[rowIndex, col];
            }

            return rowData;
        }
    }
}
