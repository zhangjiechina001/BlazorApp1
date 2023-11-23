using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database.Data
{
    public class StandardDbEntity
    {
        public int id { get; set; }
        public DateTime testtime { get; set; }
        public string sampleID { get; set; }
        public string material { get; set; }
        public string ingredient { get; set; }
        public int valid { get; set; }

        public static List<StandardDataItem> ParaseToItems(string content)
        {
            JObject obj = JObject.Parse(content);
            var element = obj["elementname"].ToArray().Select(t => t.Value<string>()).ToArray();
            var elementpercent = obj["elementpercent"].ToArray().Select(t =>t.Value<double>()).ToArray();
            List<StandardDataItem> result=new List<StandardDataItem>();
            for (int i = 0;i<element.Length;i++)
            {
                StandardDataItem item = new StandardDataItem()
                {
                    FactorName = element[i],
                    Value = elementpercent[i]
                };
                result.Add(item);
            }
            return result;
        }

        public StandardData ToStandardData()
        {
            StandardData result=new StandardData();
            result.Id= id;
            result.DateTime= testtime;
            result.SampleId = sampleID;
            result.MaterialType= material;
            result.Valid = valid;
            List<StandardDataItem> items = ParaseToItems(ingredient);
            result.Items.AddRange(items);    
            return result;
        }
    }
}
