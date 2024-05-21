using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace ZomatoApp.Dal.CountryDAL
{
    public class LOC_Country_DAL_Base : DAL_Helper
    {

        public object General(string Procedure, Object Parameters = null, string ProcedureType = null)
        {
            SqlDatabase sqlDB = new SqlDatabase(ConnString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand(Procedure);

            if (Parameters != null)
            {
                foreach (dynamic parameter in Parameters.GetType().GetProperties())
                {

                    string paramName = "@" + parameter.Key;
                    object paramValue = parameter.Value;

                    if (paramName != null && paramValue != null)
                    {
                        if (parameter is int)
                        {
                            sqlDB.AddInParameter(dbCMD, parameter.ToString(), SqlDbType.Int, parameter);
                        }
                        else if (parameter is string)
                        {
                            sqlDB.AddInParameter(dbCMD, parameter.ToString(), SqlDbType.VarChar, parameter);
                        }
                        else if (parameter is bool)
                        {
                            sqlDB.AddInParameter(dbCMD, parameter.ToString(), SqlDbType.Bit, parameter);
                        }
                        else if (parameter is DateTime)
                        {
                            sqlDB.AddInParameter(dbCMD, parameter.ToString(), SqlDbType.DateTime, parameter);
                        }
                    }
                }
            }

            DataTable dt = new DataTable();
            if (ProcedureType == "Delete")
            {
                int deleteCount = sqlDB.ExecuteNonQuery(dbCMD);
                return deleteCount;
            }
            else
            {
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
        }

        public DataTable dbo_PR_LOC_Country_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectAll");

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

        public DataTable dbo_PR_LOC_Country_SelectByPK(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

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

        public DataTable dbo_PR_LOC_Country_Insert(string CountryName)
        {
            try
            {

                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_Insert");
                sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.VarChar, CountryName);

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

        public DataTable dbo_PR_LOC_Country_Update(int CountryID, string CountryName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_Update");
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
                sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.VarChar, CountryName);

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

        public bool? dbo_PR_LOC_Country_Delete(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_Delete");
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);

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
