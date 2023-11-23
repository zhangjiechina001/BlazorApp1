using BootstrapBlazor.Components;
using DataManager.Database;
using DataManager.Database.Data;

namespace DataManager.BlazorServer.Data
{
    public class DBUtils
    {
        //public static StandDataList Inquire()
        //{
        //    using (MyDbContext context = new MyDbContext())
        //    {
        //        return context.SpectrumItems.ToList().Select(t => new SpectrumInquireItem(t));
        //    }
        //}


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
