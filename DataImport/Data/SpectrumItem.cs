using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImport.Data
{
    public class SpectrumItem
    {
        //采集时间
        [Key]
        public DateTime? SampleTime { get; set; }

        public string Location { get; set; }

        [NotMapped]
        public double[] SpectrumLamb { get; set; }

        public string SpectrumLambJson
        {
            get => SpectrumLamb != null ? string.Join(",", SpectrumLamb) : null;
            set => SpectrumLamb = value?.Split(',').Select(double.Parse).ToArray();
        }

        // 其他属性
        [NotMapped]
        public int[] Intensity { get; set; }

        public byte[] IntensityJson
        {
            get => ConvertDoubleArrayToByteArray
            set => Intensity = value?.Split(',').Select(int.Parse).ToArray();
        }

        public static byte[] ConvertDoubleArrayToByteArray(double[] doubleArray)
        {
            byte[] byteArray = new byte[doubleArray.Length * sizeof(double)];
            Buffer.BlockCopy(doubleArray, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }

        //样品个数
        public int SampleCount { get; set; }
    }
}
