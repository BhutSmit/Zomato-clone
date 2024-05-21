using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal.StateDAL
{
    public class LOC_State_DAL_Base: DAL_Helper
    {

        public DataTable dbo_PR_LOC_State_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectAll");

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

        public DataTable dbo_PR_LOC_State_SelectByPK(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

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

        public DataTable dbo_PR_LOC_State_Insert(string StateName, int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_Insert");
                sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.VarChar, StateName);
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
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

        public DataTable dbo_PR_LOC_State_Update(int StateID, string StateName, int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_Update");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);
                sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.VarChar, StateName);
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

        public bool? dbo_PR_LOC_State_Delete(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_Delete");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

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
