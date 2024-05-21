using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class MST_User_DAL_Base: DAL_Helper
    {

        public DataTable dbo_PR_MST_User_SelectByUserNameAndPassword(string UserName , string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_User_SelectByUserNameAndpassword");
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);

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

        public bool dbo_PR_MST_User_Insert(string UserName, string Password, string Email, string FirstName, string LastName, string PhoneNo, DateTime BirthDate, string Gender, bool IsAdmin, bool IsActive, int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_User_SelectByUserName");
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                if(dt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("PR_MST_User_Insert");
                    sqlDB.AddInParameter(dbCMD1, "@UserName", SqlDbType.VarChar, UserName);
                    sqlDB.AddInParameter(dbCMD1, "@Password", SqlDbType.VarChar, Password);
                    sqlDB.AddInParameter(dbCMD1, "@Email", SqlDbType.VarChar, Email);
                    sqlDB.AddInParameter(dbCMD1, "@FirstName", SqlDbType.VarChar, FirstName);
                    sqlDB.AddInParameter(dbCMD1, "@LastName", SqlDbType.VarChar, LastName);
                    sqlDB.AddInParameter(dbCMD1, "@PhoneNo", SqlDbType.VarChar, PhoneNo);
                    sqlDB.AddInParameter(dbCMD1, "@BirthDate", SqlDbType.DateTime, BirthDate);
                    sqlDB.AddInParameter(dbCMD1, "@Gender", SqlDbType.VarChar, Gender);
                    sqlDB.AddInParameter(dbCMD1, "@IsAdmin", SqlDbType.Bit, IsAdmin);
                    sqlDB.AddInParameter(dbCMD1, "@IsActive", SqlDbType.Bit, IsActive);
                    sqlDB.AddInParameter(dbCMD1, "@CityID", SqlDbType.Int, CityID);
                    if (Convert.ToBoolean(sqlDB.ExecuteNonQuery(dbCMD1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
