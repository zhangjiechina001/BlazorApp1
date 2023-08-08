using Google.Protobuf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database
{
    public class SpectrumItem
    {
        public SpectrumItem(specdata data) 
        {
            //20_230624001646
            _data = data;
        }
        specdata _data;

        public bool Save()
        {
            string dtStr = _data.Foldname.Substring(_data.Foldname.Length - 15).Replace("_","");
            string format = "yyyyMMddHHmmss";
            DateTime dateTime1 = DateTime.Now;
            DateTime.TryParseExact(dtStr, format,null,System.Globalization.DateTimeStyles.None,out dateTime1);
            //先保存图片，在保存到数据库
            DbSpectrumItem dbSpectrumItem = new DbSpectrumItem()
            {
                HaveLabel = false,
                Location = "铜陵",
                WorkLocation = "一号口",
                MashineId = "GS2200GABCDEFG",
                CreateTime = dateTime1,
                Data=_data
            };
            
            string dataPath = CreateSaveFilePath(dbSpectrumItem);
            if(File.Exists(dataPath))
            {
                return false;
            }
            SaveToDisk(dbSpectrumItem, dataPath);
            return SaveToDb(dbSpectrumItem);
        }

        private void SaveToDisk(DbSpectrumItem dbSpectrumItem, string dataPath)
        {
            dbSpectrumItem.SavePath = dataPath;
            File.WriteAllBytes(dataPath, _data.ToByteArray());
        }

        private bool SaveToDb(DbSpectrumItem dbSpectrumItem)
        {
            using(var dbContext = new MyDbContext())
            {
                dbContext.Database.EnsureCreated();
                dbContext.SpectrumItems.Add(dbSpectrumItem);
                return dbContext.SaveChanges()==1;
            }
        }

        public static string CreateSaveFilePath(DbSpectrumItem dbSpectrum)
        {
            List<string> infoList = new List<string>
            {
                dbSpectrum.HaveLabel?"有标签":"无标签",
                dbSpectrum.Location,
                dbSpectrum.WorkLocation,
                dbSpectrum.MashineId,
            }; 

            string dir = "F:\\光谱数据\\"+string.Join("\\", infoList);
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            infoList.Add(dbSpectrum.CreateTime.ToString("yyyyMMddHHmmss"));
            string fileName=string.Join("-", infoList)+ "_" + Path.GetFileName(dbSpectrum.Data.Filename);
            return Path.Combine(dir, fileName);
        }
    }

    public class DbSpectrumItem
    {
        public DbSpectrumItem()
        {

        }

        public DbSpectrumItem(specdata data,string location)
        {
            _data = data;
            MashineId = "GS2200GABCDEFG";
            HaveLabel = false;
            Location = location;
            WorkLocation = "";
            CreateTime = GetDatetime(location,_data.Foldname);
        }

        private DateTime GetDatetime(string location,string foldName)
        {
            DateTime ret = DateTime.Now;
            if (location=="铜陵")
            {
                string dtStr = foldName.Substring(foldName.Length - 13);
                string format = "yyMMddHHmmss";
                DateTime.TryParseExact(dtStr, format, null, System.Globalization.DateTimeStyles.None, out ret);
            }
            else if(location=="南京")
            {
                string dtStr = foldName.Substring(foldName.Length - 15).Replace("_", "");
                string format = "yyyyMMddHHmmss";
                DateTime.TryParseExact(dtStr, format, null, System.Globalization.DateTimeStyles.None, out ret);
            }

            return ret;
        }
        [Key]
        public int AutoIncreaseId { get; set; }

        public bool HaveLabel { get; set; }

        public string? Location { get; set; }

        public string? WorkLocation { get; set; }

        public string? MashineId { get; set; }

        public DateTime CreateTime { get; set; }

        public string SavePath { get; set; } = "";

        specdata? _data = null;
        [NotMapped]
        public specdata Data
        {
            get
            {
                if(_data== null)
                {
                    _data= specdata.Parser.ParseFrom(File.ReadAllBytes(SavePath));
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public bool Save()
        {
            string dtStr = _data.Foldname.Substring(_data.Foldname.Length - 15).Replace("_", "");
            string format = "yyyyMMddHHmmss";
            DateTime dateTime1 = DateTime.Now;
            DateTime.TryParseExact(dtStr, format, null, System.Globalization.DateTimeStyles.None, out dateTime1);
            //先保存图片，在保存到数据库
            DbSpectrumItem dbSpectrumItem = new DbSpectrumItem()
            {
                HaveLabel = false,
                Location = "铜陵",
                WorkLocation = "一号口",
                MashineId = "GS2200GABCDEFG",
                CreateTime = dateTime1,
                Data = _data
            };

            string dataPath = CreateSaveFilePath(this);
            if (File.Exists(dataPath))
            {
                return false;
            }
            SavePath = dataPath;
            SaveToDisk(dataPath);
            return SaveToDb();
        }

        private void SaveToDisk(string path)
        {
            File.WriteAllBytes(path, _data.ToByteArray());
        }

        private bool SaveToDb()
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.EnsureCreated();
                dbContext.SpectrumItems.Add(this);
                return dbContext.SaveChanges() == 1;
            }
        }

        public static string CreateSaveFilePath(DbSpectrumItem dbSpectrum)
        {
            List<string> infoList = new List<string>
            {
                dbSpectrum.HaveLabel?"有标签":"无标签",
                dbSpectrum.Location,
                dbSpectrum.WorkLocation,
                dbSpectrum.MashineId,
            };

            string dir = "F:\\光谱数据\\" + string.Join("\\", infoList);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            infoList.Add(dbSpectrum.CreateTime.ToString("yyyyMMddHHmmss"));
            string fileName = string.Join("-", infoList) + "_" + Path.GetFileName(dbSpectrum.Data.Filename);
            return Path.Combine(dir, fileName);
        }
    }
}
