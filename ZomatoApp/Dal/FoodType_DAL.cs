using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace ZomatoApp.Dal
{
    public class FoodType_DAL: FoodType_DALBase
    {

        public DataTable dbo_PR_FoodType_Filter(string FoodTypeName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodType_Filter");
                sqlDB.AddInParameter(dbCMD, "@FoodTypeName", SqlDbType.VarChar, FoodTypeName);

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

    }
}
