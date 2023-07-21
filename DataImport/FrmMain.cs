using DataImport.Data;
using ScottPlot.Drawing.Colormaps;

namespace DataImport
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        specdata _data;
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置对话框的标题
                openFileDialog.Title = "选择文件";

                // 设置对话框可接受的文件类型
                openFileDialog.Filter = "文本文件 (*.pwb)|*.pwb|所有文件 (*.*)|*.*";

                // 如果用户点击了“确定”按钮
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取用户选择的文件路径
                    string selectedFilePath = openFileDialog.FileName;
                    byte[] dataBytes = File.ReadAllBytes(selectedFilePath);

                    // 2. 解析数据为 specdata 对象
                    _data = specdata.Parser.ParseFrom(dataBytes);
                    PlotUtils.UpdateSactterLinePlot(GetSampleItems(_data).Take(10).ToList(), formsPlot1, labelVisable: false);
                }
            }
        }

        private List<SampleItem> GetSampleItems(specdata specdata)
        {
            List<SampleItem> ret = new List<SampleItem>();
            int index = 0;
            for (int i = 0; i < specdata.Speccount; i++)
            {
                SampleItem item = new SampleItem();
                item.XAxis = specdata.Speclamb.ToArray();
                List<double> values = new List<double>();
                for (int j = 0; j < specdata.Lambdacount; j++)
                {
                    values.Add(specdata.Intensity[index]);
                    index++;

                }
                item.X = values.ToArray();
                item.Name = i.ToString(); ;
                ret.Add(item);

                //specdata.
            }
            return ret;
        }

        private void Export(specdata data)
        {
            List<List<double>> val = new List<List<double>>();
            int index = 0;
            val.Add(data.Speclamb.ToList());
            for (int i = 0; i < data.Speccount; i++)
            {
                List<double> values = new List<double>();
                for (int j = 0; j < data.Lambdacount; j++)
                {
                    values.Add(data.Intensity[index]);
                    index++;

                }
                val.Add(values);

                //specdata.
            }

            using (SaveFileDialog openFileDialog = new SaveFileDialog())
            {
                // 设置对话框的标题
                openFileDialog.Title = "选择文件";

                // 设置对话框可接受的文件类型
                openFileDialog.Filter = "文本文件 (*.csv)|*.csv|所有文件 (*.*)|*.*";

                // 如果用户点击了“确定”按钮
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取用户选择的文件路径
                    string selectedFilePath = openFileDialog.FileName;
                    Export(val, selectedFilePath);
                }
            }
        }

        private void Export(IEnumerable<List<double>> data, string fn)
        {
            // 输出文件路径
            string filePath = "output.txt";

            // 将数据写入文件
            try
            {
                using (StreamWriter writer = new StreamWriter(fn))
                {
                    foreach (List<double> innerList in data)
                    {
                        // 将每个内部的 List<double> 转换为字符串并用逗号分隔
                        string line = string.Join(",", innerList);
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("数据已成功输出到文件。");
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误：" + ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_data != null)
            {
                Export(_data);
            }
        }

        private void btnExportDb_Click(object sender, EventArgs e)
        {
            if(_data == null) 
            {
                return;
            }

            using (var dbContext = new MyDbContext())
            {
                dbContext.Database.EnsureCreated();
                // 查询数据库中的实体
                var entities = dbContext.SpectrumItems.ToList();

                // 添加新实体
                var newEntity = new SpectrumItem { SampleTime = DateTime.Now, Location = "铜陵", SpectrumLamb = _data.Speclamb.ToArray(), Intensity = _data.Intensity.ToArray() };
                dbContext.SpectrumItems.Add(newEntity);
                dbContext.SaveChanges();

                Console.WriteLine("操作成功！");
            }
        }
    }
}