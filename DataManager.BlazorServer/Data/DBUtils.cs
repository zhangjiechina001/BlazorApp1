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

        public static StandDataList Inquire(StandardDataSearchModel model)
        {
            var entity = SqliteDatabase.GetInstance().Inquire(model.WorkPosition).Select(t => t.ToStandardData()).ToList();
            if(model.SearchDate?.NullStart!=null&& model.SearchDate?.NullEnd != null)
            {
                entity = entity.Where(t => t.DateTime >= model.SearchDate.Start && t.DateTime <= model.SearchDate.End).ToList();
            }
            return new StandDataList(entity);
        }
    }
}
