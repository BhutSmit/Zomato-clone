using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ZomatoApp.Models;

namespace ZomatoApp.Dal.OrderDAL
{
    public class MST_OrderDAL : MST_OrderDAL_Base
    {

        public DataTable dbo_PR_MST_Order_RestaurantWiseOrder(int RestaurantID)
            {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Order_RestaurantWiseOrder");
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);

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

        public List<StatusModel> dbo_PR_Status_Status()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Status_Status");

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                List<StatusModel> StatusList = new List<StatusModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    StatusModel model_StatusModel = new StatusModel();
                    model_StatusModel.StatusID = Convert.ToInt32(dr["StatusID"]);
                    model_StatusModel.StatusName = dr["StatusName"].ToString();
                    StatusList.Add(model_StatusModel);
                }

                return StatusList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable dbo_PR_MST_Order_Update_OrderStatus(int OrderID, int RestaurantID, int StausID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Order_Update_OrderStatus");
                sqlDB.AddInParameter(dbCMD, "@OrderID", SqlDbType.Int, OrderID);
                sqlDB.AddInParameter(dbCMD, "@RestaurantID", SqlDbType.Int, RestaurantID);
                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, StausID);

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

    }
}
