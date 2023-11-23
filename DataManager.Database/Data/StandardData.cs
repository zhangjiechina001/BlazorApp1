using System.Diagnostics.CodeAnalysis;

namespace DataManager.Database.Data
{
    public class StandardData
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string SampleId { get; set; }

        public string MaterialType { get; set; }

        public int Valid { get; set; }

        public double? GetFactorValue(string factorName)
        {
            var inquire = Items.Where(t => t.FactorName == factorName).ToList();
            return inquire.Any() ? inquire[0].Value : null;
        }

        public List<StandardDataItem> Items { get; private set; } = new List<StandardDataItem>();
    }

    public class StandardDataItem
    {
        private readonly string _format = "";

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

        public string FactorName { get; set; }

        public double? Value { get; set; }

        public string DisplayValue => Value == null ? "--" : Value.Value.ToString(_format);

        public double FormatValue => Value ?? -0.01;

        //public override bool Equals(object obj)
        //{
        //    if (obj is StandardDataItem other)
        //        return this == other;

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return FactorName.GetHashCode();
        //}

    }
}
