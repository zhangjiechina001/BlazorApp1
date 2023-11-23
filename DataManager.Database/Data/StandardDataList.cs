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
            return this.First().Items.Select(x => x.FactorName).ToList();
        }

        public List<string> GetAllSampleTypes()
        {
            return this.Select(t => t.MaterialType).Distinct().ToList();
        }

        public List<double> GetFactorValue(string factor)
        {
            List<double> result = this.Select(t => t.GetFactorValue(factor)).Where(t => t.HasValue).Select(t => t.Value).ToList();
            return result;
        }

        public SysDataTable GetDataTeble()
        {
            SysDataTable table = new SysDataTable();
            List<string> headers = new List<string>() { "时间", "样品编号", "类型" };
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
                newRow[0] = item.DateTime.ToString("yyyy-MM-dd_hh:mm:ss");
                newRow[1] = item.SampleId;
                newRow[2] = item.MaterialType;
                for (int j = 0; j < table.Columns.Count - headerIndex; j++)
                {
                    newRow[headerIndex + j] = item.Items[j].Value == null ? "--" : item.Items[j].Value.Value.ToString("G4");
                };
                table.Rows.Add(newRow);
            }

            return table;
        }

        public static StandDataList CreateSampleList()
        {
            StandDataList result=new StandDataList();
            DateTime dt= DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                StandardData item = new StandardData()
                {
                    DateTime = dt.AddMinutes(1),
                    SampleId = "ABCDEFG",
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
