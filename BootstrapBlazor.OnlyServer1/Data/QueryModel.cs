using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;

namespace BootstrapBlazor.OnlyServer1.Data
{
    public class QueryModel
    {
        [Display(Name ="查询时间")]
        public DateTimeRangeValue DateTimeRangeValue { get; set; } = new();

        [Display(Name = "地点")]
        public string Location { get; set; } = "";
    }
}
