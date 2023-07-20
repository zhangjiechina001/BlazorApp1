using DataImport.Data;

namespace DataImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                    specdata data = specdata.Parser.ParseFrom(dataBytes);
                    PlotUtils.UpdateSactterLinePlot(GetSampleItems(data).Take(30).ToList(),formsPlot1);
                }
            }
        }

        private List<SampleItem> GetSampleItems(specdata specdata)
        {
            List<SampleItem> ret = new List<SampleItem>();
            int index = 0;
            for (int i = 0; i < specdata.Speccount; i++)
            {
                SampleItem item=new SampleItem();
                item.XAxis = specdata.Speclamb.ToArray();
                List<double> values=new List<double>();
                for (int j = 0; j < specdata.Lambdacount; j++)
                {
                    values.Add(specdata.Intensity[index]);
                    index++;
                    
                }
                item.X = values.ToArray();
                item.Name=i.ToString(); ;
                ret.Add(item);
                //specdata.
            }
            return ret;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}