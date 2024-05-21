using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal.User
{
    public class User_DAL : User_DAL_Base
    {

        public DataTable dbo_PR_Restaurant_SelectAllFavourate()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_SelectAllFavourate");

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

        public DataTable dbo_PR_Restaurant_Favourate(int RestaurantID, bool IsFavourate)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_Favourate");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@IsFavourate", SqlDbType.Bit, IsFavourate);

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

        public DataTable dbo_PR_FoodType_SelectAllFavourate()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_SelectAllFavourate");

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

        public DataTable dbo_PR_MST_Food_SelectAllFavourate()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Food_SelectAllFavourate");

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

        public DataTable dbo_PR_Cart_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_SelectAll");

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

        public DataTable dbo_PR_Cart_SelectByFoodID(int FoodID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_SelectByFoodID");
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);

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

        public DataTable dbo_PR_Cart_Insert(int FoodID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_Insert");
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);

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

        public bool? dbo_PR_Cart_Delete(int CartID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_Delete");
                sqlDB.AddInParameter(dbCMD, "@CartID", SqlDbType.Int, CartID);

                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dbo_PR_Cart_Update(int CartID, int FoodID, int Quantity)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_Update");
                sqlDB.AddInParameter(dbCMD, "@CartID", SqlDbType.Int, CartID);
                //sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);
                sqlDB.AddInParameter(dbCMD, "@Quantity", SqlDbType.Int, Quantity);

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

        public DataTable dbo_PR_MST_Order_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Order_SelectAll");

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

        public DataTable dbo_PR_MST_Order_Insert(int RestaurantID, int FoodTypeID, int FoodID, int Quantity, int Amount, int TotalAmount, string Address)
        {
            int StatusID = 2;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Order_Insert");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@FoodTypeID", SqlDbType.Int, FoodTypeID);
                sqlDB.AddInParameter(dbCMD, "@FoodID", SqlDbType.Int, FoodID);
                sqlDB.AddInParameter(dbCMD, "@Quantity", SqlDbType.Int, Quantity);
                sqlDB.AddInParameter(dbCMD, "@Amout", SqlDbType.Int, Amount);
                sqlDB.AddInParameter(dbCMD, "@TotalAmount", SqlDbType.Int, TotalAmount);
                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, StatusID);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, Address);

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

        public bool? dbo_PR_MST_Order_Delete(int OrderID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Order_Delete");
                sqlDB.AddInParameter(dbCMD, "@OrderID", SqlDbType.Int, OrderID);

                int delete = sqlDB.ExecuteNonQuery(dbCMD);

                return (delete == -1 ? false : true);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable dbo_PR_Restaurant_SelectAll_ByCityList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_SelectALl_ByCityList");

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

        public DataTable dbo_PR_Restaurant_SelectAll_ByCityName(string CityName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Restaurant_SelectAll_ByCityName");
                sqlDB.AddInParameter(dbCMD, "@CityName", SqlDbType.VarChar, CityName);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch( Exception ex)
            {
                return null;
            }
        }

    }
}
