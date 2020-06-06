using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    
    public class ShenheDAL
    {
        
        //审核入库
        public int Upts(Values m)
        {
            string sql = string.Format("update Stockin set StockInStatus=1, ModifiedBy='{0}', ModifiedDate='{1}' where StockInId={2}", m.name, m.times, m.id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核入库明细
        public int Uptss(Values m)
        {
            string sql = string.Format("update Stockindetail set Status=1, AuditinId='{0}', AuditinTime='{1}', ModifiedBy='{2}', ModifiedDate='{3}' where StockInId={4}", m.name, m.times, m.name, m.times, m.id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核出库
        public int Upte(Values m)
        {
            string sql = string.Format("update Stockout set StockOutStatus=1, ModifiedBy='{0}', ModifiedDate='{1}' where StockInId={2}", m.name, m.times, m.id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //审核出库明细
        public int Uptee(Values m)
        {
            string sql = string.Format("update Stockoutdetail set Status=1, AuditinId='{0}', AuditinTime='{1}', ModifiedBy='{2}', ModifiedDate='{3}' where StockInId={4}", m.name, m.times, m.name, m.times, m.id);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
    
}
