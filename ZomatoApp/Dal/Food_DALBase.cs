using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace ZomatoApp.Dal
{
    public class Food_DALBase: DAL_Helper
    {

        public DataTable dbo_PR_FoodTypeWiseFood(int FoodTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodTypeWiseFood");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);

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

        public DataTable dbo_PR_Food_SelectByPK(int FoodID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);

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

        public DataTable dbo_PR_MST_Food_Insert(string FoodName, int RestaurantID, string Description, decimal Price, bool IsVegiterian, string FoodImage, int FoodTypeID, bool IsActive, decimal Review)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_Insert");
                sqlDB.AddInParameter(dbCMD, "@FoodName", SqlDbType.VarChar, FoodName);
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.VarChar, Description);
                sqlDB.AddInParameter(dbCMD, "@Price", SqlDbType.Decimal, Price);
                sqlDB.AddInParameter(dbCMD, "@IsVegiterian", SqlDbType.Bit, IsVegiterian);
                sqlDB.AddInParameter(dbCMD, "@FoodImage", SqlDbType.VarChar, FoodImage);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);
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

        public DataTable dbo_PR_MST_Food_Update(int FoodID, int RestaurantID, string FoodName, string Description, decimal Price, bool IsVegiterian, string FoodImage, int FoodTypeID, bool IsActive, decimal Review)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_Update");
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@FoodName", SqlDbType.VarChar, FoodName);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.VarChar, Description);
                sqlDB.AddInParameter(dbCMD, "@Price", SqlDbType.Decimal, Price);
                sqlDB.AddInParameter(dbCMD, "@IsVegiterian", SqlDbType.Bit, IsVegiterian);
                sqlDB.AddInParameter(dbCMD, "@FoodImage", SqlDbType.VarChar, FoodImage);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, IsActive);
                sqlDB.AddInParameter(dbCMD, "@Review", SqlDbType.Decimal, Review);

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

        public bool? dbo_PR_MST_Food_Delete(int FoodID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_Delete");
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);

                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
