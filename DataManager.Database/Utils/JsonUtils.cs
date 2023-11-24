using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataManager.Database.Utils
{
    public static class JsonUtils
    {
        public static JObject LoadJson(string title)
        {
            string targetPath=Path.Combine(".\\Config", title+".json");
            string absouutePath = Path.GetFullPath(targetPath);
            if (!Directory.Exists(".\\Config"))
            {
                Directory.CreateDirectory(".\\Config");
               
                throw new IOException($"配置文件{absouutePath}未找到！");
            }

            string jsonContext=File.ReadAllText(targetPath);
            JObject obj = JObject.Parse(jsonContext);
            return obj;
        }

        public static JObject LoadJsonFromFile(string filePath)
        {
            string absouutePath = Path.GetFullPath(filePath);
            if (!File.Exists(absouutePath))
            {
                throw new IOException($"配置文件{absouutePath}未找到！");
            }

            string jsonContext = File.ReadAllText(absouutePath);
            JObject obj = JObject.Parse(jsonContext);
            return obj;
        }
    }
}
