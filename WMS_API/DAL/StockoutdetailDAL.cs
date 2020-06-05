using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class StockoutdetailDAL
    {
        //显示出库审核列表
        public List<StockoutDetail> Show()
        {
            string sql = "select * from Stockin";
            return DBHelper.GetToList<StockoutDetail>(sql);
        }
        //添加出库审核
        public int Add(StockoutDetail m)
        {
            string sql = string.Format("insert into Stockin values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", m.StockOutId, m.Status, m.PlanOutQty, m.ActOutQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //修改反填
        public StockoutDetail Find(int id)
        {
            string sql = "select * from Stockoutdetail where StockInDetailId=" + id;
            return DBHelper.GetToList<StockoutDetail>(sql).FirstOrDefault();
        }
        //修改
        public int Upt(StockoutDetail m)
        {
            string sql = string.Format("update Stockoutdetail set StockOutId='{0}',Status='{1}',PlanInQty='{2}',ActInQty='{3}',StoragerackId='{4}',AuditinId='{5}',AuditinTime='{6}',Remark='{7}',CreateBy='{8}',CreateDate='{9}',ModifiedBy='{10}',ModifiedDate='{11}' where StockInDetailId={12})", m.StockOutId, m.Status, m.PlanOutQty, m.ActOutQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate, m.StockInDetailId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除
        public int Del(int id)
        {
            string sql = "delete from Stockoutdetail where StockInDetailId=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
