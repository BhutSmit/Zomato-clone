using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace ZomatoApp.Dal
{
    public class Restaurant_DAL: Restaurant_DALBase
    {
        public DataTable dbo_PR_Restaurant_Filter(string RestaurantName, string Address, bool? IsActive)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("PR_Restaurant_Filter");
                sqlDB.AddInParameter(cmd, "@RestaurantName", SqlDbType.VarChar, RestaurantName);
                sqlDB.AddInParameter(cmd, "@Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(cmd, "@IsActive", SqlDbType.Bit, IsActive);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
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
