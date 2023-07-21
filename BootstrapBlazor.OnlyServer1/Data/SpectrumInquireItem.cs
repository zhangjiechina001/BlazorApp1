using DataManager.Database;
using System.ComponentModel.DataAnnotations;

namespace BootstrapBlazor.OnlyServer1.Data
{
    public class SpectrumInquireItem
    {
        public SpectrumInquireItem(DbSpectrumItem item)
        {
            Location = item.Location;
            HaveLabel = item.HaveLabel;
            WorkLocation = item.WorkLocation;
            MashineId = item.MashineId;
            CreateTime= item.CreateTime;
            SavePath = item.SavePath;
        }

        public bool HaveLabel { get; set; }

        public string Location { get; set; }

        public string WorkLocation { get; set; }

        public string MashineId { get; set; }

        public DateTime CreateTime { get; set; }

        public string SavePath { get; set; }


    }
}
