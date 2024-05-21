using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class Food_DAL: Food_DALBase
    {

        public DataTable dbo_PR_MST_Food_Filter(int RestaurantID, int FoodTypeID, string FoodName, decimal? Price, int MinPrice, int MaxPrice, bool? IsVegiterian, bool? IsActive, decimal? Review)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_Filter");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);
                sqlDB.AddInParameter(dbCMD, "@FoodName", SqlDbType.VarChar, FoodName);
                //sqlDB.AddInParameter(dbCMD, "@Price", SqlDbType.Decimal, Price);
                sqlDB.AddInParameter(dbCMD, "@MinPrice", SqlDbType.Int, MinPrice);
                sqlDB.AddInParameter(dbCMD, "@MaxPrice", SqlDbType.Int, MaxPrice);
                sqlDB.AddInParameter(dbCMD, "@IsVegiterian", SqlDbType.Bit, IsVegiterian);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, IsActive);
                sqlDB.AddInParameter(dbCMD, "@Review", SqlDbType.Decimal, Review);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
