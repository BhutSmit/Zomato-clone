using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using ZomatoApp.Areas.LOC_Country.Models;

namespace ZomatoApp.Dal.StateDAL
{
    public class LOC_State_DAL: LOC_State_DAL_Base
    {

        public List<LOC_CountryDropDownModel> dbo_PR_LOC_Country_ComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_ComboBox");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                List<LOC_CountryDropDownModel> CountryList = new List<LOC_CountryDropDownModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    LOC_CountryDropDownModel model_CountryName = new LOC_CountryDropDownModel();
                    model_CountryName.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model_CountryName.CountryName = dr["CountryName"].ToString();
                    CountryList.Add(model_CountryName);
                }

                return CountryList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
