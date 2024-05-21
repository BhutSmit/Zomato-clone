using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class Restaurant_DALBase: DAL_Helper
    {

        public DataTable dbo_PR_Restaurant_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_SelectAll");

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

        public DataTable dbo_PR_Restaurant_SelectByPK(int? RestauratID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestauratID);

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

        public DataTable dbo_PR_Restaurant_Insert(string RestaurantName , string RestaurantImage, string Address , string PhoneNo , string Email , decimal Rating , DateTime OpeningTime , DateTime ClosingTime , bool IsActive , int CityID)
        {
            try 
            {

                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_Insert");
                sqlDB.AddInParameter(dbCMD, "@RestaurantName", SqlDbType.VarChar, RestaurantName);
                sqlDB.AddInParameter(dbCMD, "@RestaurantImage", SqlDbType.VarChar, RestaurantImage);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "@PhoneNo", SqlDbType.VarChar, PhoneNo);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "@Rating", SqlDbType.Decimal, Rating);
                sqlDB.AddInParameter(dbCMD, "@OpeningTime", SqlDbType.DateTime, OpeningTime);
                sqlDB.AddInParameter(dbCMD, "@ClosingTime", SqlDbType.DateTime, ClosingTime);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, IsActive);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);

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

        public DataTable dbo_PR_Restaurant_Update(int RestaurantID, string RestaurantName, string RestaurantImage, string Address, string PhoneNo, string Email, decimal Rating, DateTime OpeningTime, DateTime ClosingTime, bool IsActive, int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_Update");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@RestaurantName", SqlDbType.VarChar, RestaurantName);
                sqlDB.AddInParameter(dbCMD, "@RestaurantImage", SqlDbType.VarChar, RestaurantImage);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "@PhoneNo", SqlDbType.VarChar, PhoneNo);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "@Rating", SqlDbType.Decimal, Rating);
                sqlDB.AddInParameter(dbCMD, "@OpeningTime", SqlDbType.DateTime, OpeningTime);
                sqlDB.AddInParameter(dbCMD, "@ClosingTime", SqlDbType.DateTime, ClosingTime);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, IsActive);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);

                DataTable dt = new DataTable();
                int r = sqlDB.ExecuteNonQuery(dbCMD);

                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public bool? dbo_PR_Restaurant_Delete(int RestaurantID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_Delete");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);

                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public DataTable dbo_PR_RestaurentWiseFoodtype(int RestaurantID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RestaurantWiseFoodType");

                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch( Exception e )
            {
                return null;
            }
        }

        public DataTable dbo_PR_FoodTypeWiseFood(int FoodTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodTypeWiseFood");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch ( Exception e )
            {
                return null;
            }
        }

    }
}
