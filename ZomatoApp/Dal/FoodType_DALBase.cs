using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class FoodType_DALBase: DAL_Helper
    {

        public DataTable dbo_PR_RestaurentWiseFoodtype(int RestaurantID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RestaurantWiseFoodType");

                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DataTable dbo_PR_FoodType_SelectByPK(int FoodTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public DataTable dbo_PR_FoodType_Insert(string FoodTypeName, int RestaurantID, string FoodTypeImage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_Insert");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeName", SqlDbType.VarChar, FoodTypeName);
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeImage", SqlDbType.VarChar, FoodTypeImage);

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

        public DataTable dbo_PR_FoodType_Update(int FoodTypeID , string FoodTypeName, int RestaurantID , string FoodTypeImage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_Update");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeName", SqlDbType.VarChar, FoodTypeName);
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeImage", SqlDbType.VarChar, FoodTypeImage);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool? dbo_PR_FoodType_Delete(int FoodTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_Delete");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);

                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
