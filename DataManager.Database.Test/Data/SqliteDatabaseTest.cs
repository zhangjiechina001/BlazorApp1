using DataManager.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database.Test.Data
{
    [TestClass]
    public class SqliteDatabaseTest
    {
        private readonly SqliteDatabase database;
        public SqliteDatabaseTest() 
        {
            database = SqliteDatabase.GetInstance();
            database.Init("F:\\C#Project\\BlazorDataBoard\\DataManager.Database.Test\\bin\\Debug\\net6.0\\LIBSDataBase");
        }

        //[TestMethod]
        //public void TestInit()
        //{
        //    Assert.IsTrue(database.Init("F:\\C#Project\\BlazorDataBoard\\DataManager.Database.Test\\bin\\Debug\\net6.0\\LIBSDataBase"));
        //}

        [TestMethod]
        public void TestInquire()
        {
            var items=database.Inquire("IngredientTbl_192_168_1_4New");
            Assert.IsTrue(items.Count==665);
        }
    }
}
