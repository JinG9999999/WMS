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
            string sql = "select * from StockoutDetail";
            return DBHelper.GetToList<StockoutDetail>(sql);
        }
        //添加出库审核
        public int Add(StockoutDetail m)
        {
            string sql = string.Format("insert into StockoutDetail values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", m.StockOutId, m.Status, m.PlanOutQty, m.ActOutQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate);
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
            string sql = string.Format("update Stockoutdetail set PlanOutQty='{0}',ActOutQty='{1}',StoragerackId='{2}',AuditinId='{3}',AuditinTime='{4}',Remark='{5}',CreateBy='{6}',CreateDate='{7}',ModifiedBy='{8}',ModifiedDate='{9}' where StockInDetailId={10}", m.PlanOutQty, m.ActOutQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate, m.StockInDetailId);
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
