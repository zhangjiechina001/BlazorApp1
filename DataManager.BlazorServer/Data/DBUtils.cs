using BootstrapBlazor.Components;
using DataManager.Database;
using DataManager.Database.Data;

namespace DataManager.BlazorServer.Data
{
    public class DBUtils
    {
        public static StandDataList Inquire()
        {
            var entity=SqliteDatabase.GetInstance().Inquire("IngredientTbl_192_168_1_4New").Select(t=>t.ToStandardData()).ToList();
            return new StandDataList(entity);
        }

        public static StandDataList Inquire(string tableName)
        {
            var entity = SqliteDatabase.GetInstance().Inquire(tableName).Select(t => t.ToStandardData()).ToList();
            return new StandDataList(entity);
        }

        public static StandDataList Inquire(IEnumerable<IFilterAction> filter)
        {
            //SqliteDatabase.GetInstance().Inquire("");
            //using (MyDbContext context = new MyDbContext())
            //{
            //    var ret = context.SpectrumItems.Select(t => new SpectrumInquireItem(t)).Where(filter.GetFilterFunc<SpectrumInquireItem>()).ToList();
            //    return ret;
            //}
            return null;
        }
    }
}
