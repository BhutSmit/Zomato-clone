using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class Home_DAL: Home_DAL_Base
    {
        public DataTable dbo_PR_RecordCount()
        {

            try
            {
                SqlDatabase sqlDb = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDb.GetStoredProcCommand("PR_RecordCount");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCMD))
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
