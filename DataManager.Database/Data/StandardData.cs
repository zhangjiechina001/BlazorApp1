using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DataManager.Database.Data
{
    public class StandardData : ICloneable
    {
        /// <summary>
        /// 数据id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 数据生成时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 样品id
        /// </summary>
        public string? SampleId { get; set; }

        /// <summary>
        /// 样品类型(可能要去掉\r)
        /// </summary>
        public string? MaterialType { get; set; }

        /// <summary>
        /// 数据有效性,1有效
        /// </summary>
        public int Valid { get; set; }

        public double? GetFactorValue(string factorName)
        {
            var inquire = Items.Where(t => t.FactorName == factorName).ToList();
            return inquire.Any() ? inquire[0].Value : null;
        }

        public double? GetDisplayFactorValue(string factorName)
        {
            var inquire = Items.Where(t => t.FactorName == factorName).ToList();
            string? valStr = inquire.Any() ? inquire[0].DisplayValue : null;
            return valStr == null ? null : double.Parse(valStr);
        }

        public object Clone()
        {
            string jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<StandardData>(jsonString);
        }

        /// <summary>
        /// 样品详细数据
        /// </summary>
        public List<StandardDataItem> Items { get; private set; } = new List<StandardDataItem>();
    }

    public class StandardDataItem
    {
        private string _format = "";

        public StandardDataItem()
        {
            _format = "G4";
        }

        public StandardDataItem(string name, double? value)
        {
            FactorName = name;
            Value = value;
            _format = "G4";
        }

        public void SetFormat(string format)
        {
            _format = format;
        }

        /// <summary>
        /// 元素名
        /// </summary>
        public string FactorName { get; set; }

        /// <summary>
        /// 元素值
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// 显示字符
        /// </summary>
        public string DisplayValue => Value == null ? "--" : Value.Value.ToString(_format);

    }
}
