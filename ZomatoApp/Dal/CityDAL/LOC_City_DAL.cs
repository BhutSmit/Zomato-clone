using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using ZomatoApp.Areas.LOC_City.Models;
using ZomatoApp.Areas.LOC_Country.Models;
using ZomatoApp.Areas.LOC_State.Models;

namespace ZomatoApp.Dal.CityDAL
{
    public class LOC_City_DAL: LOC_City_DAL_Base
    {

        public List<LOC_CityModel> dbo_PR_LOC_City_ComboBox(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_ComboBox");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

                List<LOC_CityModel> CityList = new List<LOC_CityModel>();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    while (dr.Read())
                    {
                        LOC_CityModel model_LOC_City = new LOC_CityModel();
                        model_LOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                        model_LOC_City.CityName = dr["CityName"].ToString();
                        CityList.Add(model_LOC_City);
                    }
                }

                return CityList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LOC_StateDropDownModel> dbo_PR_LOC_StateByCountryID(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_StateByCountryID");
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
                //sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

                List<LOC_StateDropDownModel> StateList = new List<LOC_StateDropDownModel>();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    while (dr.Read())
                    {
                        LOC_StateDropDownModel model_LOC_State = new LOC_StateDropDownModel();
                        model_LOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                        model_LOC_State.StateName = dr["StateName"].ToString();
                        StateList.Add(model_LOC_State);
                    }
                }

                return StateList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LOC_StateDropDownModel> dbo_PR_LOC_StateComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_StateComboBox");

                List<LOC_StateDropDownModel> StateList = new List<LOC_StateDropDownModel>();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    while (dr.Read())
                    {
                        LOC_StateDropDownModel model_LOC_State = new LOC_StateDropDownModel();
                        model_LOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                        model_LOC_State.StateName = dr["StateName"].ToString();
                        StateList.Add(model_LOC_State);
                    }
                }

                return StateList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LOC_CityDropDownModel> dbo_PR_LOC_City_ComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_ComboBox");

                List<LOC_CityDropDownModel> CityList = new List<LOC_CityDropDownModel>();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    while (dr.Read())
                    {
                        LOC_CityDropDownModel model_LOC_City = new LOC_CityDropDownModel();
                        model_LOC_City.CityID= Convert.ToInt32(dr["CityID"]);
                        model_LOC_City.CityName = dr["CityName"].ToString();
                        CityList.Add(model_LOC_City);
                    }
                }

                return CityList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LOC_CityDropDownModel> dbo_PR_LOC_City_SelectByStateID(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByStateID");
                sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);

                List<LOC_CityDropDownModel> CityList = new List<LOC_CityDropDownModel>();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    while (dr.Read())
                    {
                        LOC_CityDropDownModel model_LOC_City = new LOC_CityDropDownModel();
                        model_LOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                        model_LOC_City.CityName = dr["CityName"].ToString();
                        CityList.Add(model_LOC_City);
                    }
                }

                return CityList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
