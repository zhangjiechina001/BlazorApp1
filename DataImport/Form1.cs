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
                // ���öԻ���ı���
                openFileDialog.Title = "ѡ���ļ�";

                // ���öԻ���ɽ��ܵ��ļ�����
                openFileDialog.Filter = "�ı��ļ� (*.pwb)|*.pwb|�����ļ� (*.*)|*.*";

                // ����û�����ˡ�ȷ������ť
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ��ȡ�û�ѡ����ļ�·��
                    string selectedFilePath = openFileDialog.FileName;
                    byte[] dataBytes = File.ReadAllBytes(selectedFilePath);

                    // 2. ��������Ϊ specdata ����
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