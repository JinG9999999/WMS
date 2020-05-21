using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    
    public class ShenheDAL
    {
        //审核入库
        public int Upts(int id, string name,Nullable<DateTime> times)
        {
            string sql = string.Format("update Stockin set StockInStatus=1 ModifiedBy='{0}' ModifiedDate='{1}' where StockInId={2}", name, times, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核入库明细
        public int Uptss(int id, string name, Nullable<DateTime> times)
        {
            string sql = string.Format("update Stockindetail set StockInStatus=1 AuditinId='{0}' AuditinTime='{1}' ModifiedBy='{2}' ModifiedDate='{3}' where StockInId={4}", name, times, name, times, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核出库
        public int Upte(int id, string name, Nullable<DateTime> times)
        {
            string sql = string.Format("update Stockout set StockOutStatus=1 ModifiedBy='{0}' ModifiedDate='{1}' where StockInId={2}", name, times, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核出库明细
        public int Uptee(int id, string name, Nullable<DateTime> times)
        {
            string sql = string.Format("update Stockoutdetail set Status=1 AuditinId='{0}' AuditinTime='{1}' ModifiedBy='{2}' ModifiedDate='{3}' where StockInId={4}", name, times, name, times, id);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
    
}
