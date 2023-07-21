using DataManager.Database;
using System.ComponentModel.DataAnnotations;

namespace DataManager.BlazorServer.Data
{
    public class SpectrumInquireItem
    {
        public SpectrumInquireItem() 
        { }

        DbSpectrumItem? _item = null;
        public SpectrumInquireItem(DbSpectrumItem item)
        {
            Location = item.Location;
            HaveLabel = item.HaveLabel;
            WorkLocation = item.WorkLocation;
            MashineId = item.MashineId;
            CreateTime= item.CreateTime;
            SavePath = item.SavePath;
            _item = item;
        }

        [Display(Name ="有标签")]
        public bool HaveLabel { get; set; }

        [Display(Name ="地点")]
        public string Location { get; set; }

        [Display(Name = "工作地点")]
        public string WorkLocation { get; set; }

        [Display(Name = "设备码")]
        public string MashineId { get; set; }

        [Display(Name = "生成时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "保存路径")]
        public string SavePath { get; set; }

        public List<(double,double)> GetSpectrum()
        {
            List<(double, double)> ret = new List<(double, double)>();
            for (int i = 0; i < _item.Data.Lambdacount; i++)
            {
                ret.Add((_item.Data.Speclamb[i], _item.Data.Intensity[i]));
            }
            return ret;
        }

        public static IEnumerable<SpectrumInquireItem> Inquire()
        {
            using (MyDbContext context=new MyDbContext())
            {
                return context.SpectrumItems.ToList().Select(t=>new SpectrumInquireItem(t));
            }
        }
    }
}
