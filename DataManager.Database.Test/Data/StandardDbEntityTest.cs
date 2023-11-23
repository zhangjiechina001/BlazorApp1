using DataManager.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database.Test.Data
{
    [TestClass]
    public class StandardDbEntityTest
    {
        [TestMethod]
        public void TestParaseToItems()
        {
            string content = "{\"elementname\":[\"Cu\",\"S\",\"Fe\",\"Fe3O4\",\"SiO2\",\"CaO\",\"JZ\"],\"elementpercent\":[23.216098,0.41017,33.732219,24.606765,1.200545,11.957122,0.069444],\"statusID\":1}";
            var items=StandardDbEntity.ParaseToItems(content);
            Assert.IsTrue(items.Count == 7);
            Assert.IsTrue(items[0].Value== 23.216098);
            Assert.IsTrue(items[0].FactorName == "Cu");
        }
    }
}
