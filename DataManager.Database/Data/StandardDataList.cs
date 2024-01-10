using SysDataTable = System.Data.DataTable;

namespace DataManager.Database.Data
{
    public class StandDataList : List<StandardData>
    {
        public StandDataList(IEnumerable<StandardData> items)
        {
            this.AddRange(items);
        }

        public StandDataList()
        {
        }

        public List<string> GetAllFactors()
        {
            HashSet<string> result = new HashSet<string>();
            foreach (StandardData item in this)
            {
                var factors = item.Items.Select(x => x.FactorName);
                foreach (var factor in factors)
                {
                    result.Add(factor);
                }
            }
            if (result.Contains("None"))
            {
                result.Remove("None");
            }
            return result.ToList();
        }

        public List<string> GetAllSampleTypes()
        {
            return this.Select(t => t.MaterialType).Distinct().ToList();
        }

        public List<StandardData> GetFormatList(Dictionary<string, string> formatDic)
        {
            List<StandardData> result = new List<StandardData>();
            for (int i = 0; i < this.Count; i++)
            {
                StandardData cloneData = (this[i].Clone() as StandardData)!;
                cloneData.Items.Clear();
                foreach (var item in this[i].Items)
                {
                    if (formatDic.ContainsKey(item.FactorName))
                    {
                        item.SetFormat(formatDic[item.FactorName]);
                        cloneData.Items.Add(item);
                    }
                }
                result.Add(cloneData);
            }
            return result;

        }

        public List<double> GetFactorValue(string factor)
        {
            List<double> result = this.Select(t => t.GetFactorValue(factor)).Where(t => t.HasValue).Select(t => t.Value).ToList();
            return result;
        }

        public SysDataTable GetDataTeble()
        {
            SysDataTable table = new SysDataTable();
            List<string> headers = new List<string>() { "序列", "时间", "样品编号", "类型" };
            int headerIndex = headers.Count();
            headers.AddRange(this.GetAllFactors());
            foreach (var item in headers)
            {
                table.Columns.Add(item);
            }
            for (int i = 0; i < this.Count; i++)
            {
                var newRow = table.NewRow();
                var item = this[i];
                newRow[0] = item.Id;
                newRow[1] = item.DateTime.ToString("yyyy-MM-dd_HH:mm:ss");
                newRow[2] = item.SampleId;
                newRow[3] = item.MaterialType.Replace("\r", "");

                if (item.MaterialType == "未知")
                {
                    for (int j = 0; j < table.Columns.Count - headerIndex; j++)
                    {
                        newRow[headerIndex + j] = "--";
                    }
                }
                else
                {
                    for (int j = 0; j < table.Columns.Count - headerIndex; j++)
                    {
                        string factorName = headers[j + headerIndex];
                        var val = item.GetFactorValue(factorName);
                        newRow[headerIndex + j] = val == null ? "--" : val.Value.ToString("G4");
                    }
                }
                table.Rows.Add(newRow);
            }

            return table;
        }

        public static StandDataList CreateSampleList()
        {
            StandDataList result = new StandDataList();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                StandardData item = new StandardData()
                {
                    DateTime = dt.AddMinutes(1),
                    SampleId = "示例数据",
                    MaterialType = "BTG",
                };
                item.Items.Add(new StandardDataItem("Cu", 20.3));
                item.Items.Add(new StandardDataItem("S", 20.3));
                item.Items.Add(new StandardDataItem("Fe", 22.3));
                item.Items.Add(new StandardDataItem("Si", null));
                result.Add(item);
            }
            return result;
        }
    }
}
