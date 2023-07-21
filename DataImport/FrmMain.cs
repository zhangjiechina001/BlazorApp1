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
                // ���öԻ���ı���
                openFileDialog.Title = "ѡ���ļ�";

                // ���öԻ���ɽ��ܵ��ļ�����
                openFileDialog.Filter = "�ı��ļ� (*.csv)|*.csv|�����ļ� (*.*)|*.*";

                // ����û�����ˡ�ȷ������ť
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ��ȡ�û�ѡ����ļ�·��
                    string selectedFilePath = openFileDialog.FileName;
                    Export(val, selectedFilePath);
                }
            }
        }

        private void Export(IEnumerable<List<double>> data, string fn)
        {
            // ����ļ�·��
            string filePath = "output.txt";

            // ������д���ļ�
            try
            {
                using (StreamWriter writer = new StreamWriter(fn))
                {
                    foreach (List<double> innerList in data)
                    {
                        // ��ÿ���ڲ��� List<double> ת��Ϊ�ַ������ö��ŷָ�
                        string line = string.Join(",", innerList);
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("�����ѳɹ�������ļ���");
            }
            catch (Exception ex)
            {
                Console.WriteLine("��������" + ex.Message);
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
                // ��ѯ���ݿ��е�ʵ��
                var entities = dbContext.SpectrumItems.ToList();

                // �����ʵ��
                var newEntity = new SpectrumItem { SampleTime = DateTime.Now, Location = "ͭ��", SpectrumLamb = _data.Speclamb.ToArray(), Intensity = _data.Intensity.ToArray() };
                dbContext.SpectrumItems.Add(newEntity);
                dbContext.SaveChanges();

                Console.WriteLine("�����ɹ���");
            }
        }
    }
}