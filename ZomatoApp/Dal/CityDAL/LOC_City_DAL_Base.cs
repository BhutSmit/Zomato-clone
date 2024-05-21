using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using ZomatoApp.Areas.LOC_City.Models;

namespace ZomatoApp.Dal.CityDAL
{
    public class LOC_City_DAL_Base: DAL_Helper
    {

        public DataTable dbo_PR_LOC_City_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectAll");

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

        public DataTable dbo_PR_LOC_City_SelectByPK(int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByPK");
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

        public DataTable dbo_PR_LOC_City_Insert(string CityName, int StateID, int CountryID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDb.GetStoredProcCommand("PR_LOC_City_Insert");
                sqlDb.AddInParameter(dbCMD, "@CityName", SqlDbType.VarChar, CityName);
                sqlDb.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);
                sqlDb.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(dbCMD))
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

        public DataTable dbo_PR_LOC_City_Update(int CityID, string CityName, int StateID, int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_Update");
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);
                sqlDB.AddInParameter(dbCMD, "@CityName", SqlDbType.VarChar, CityName);
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

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

        public bool? dbo_PR_LOC_City_Delete(int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_Delete");
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);

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
