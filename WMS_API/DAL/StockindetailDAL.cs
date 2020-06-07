using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class StockindetailDAL
    {
        //显示入库审核列表
        public List<Stockindetail> Show()
        {
            string sql = "select * from Stockindetail";
            return DBHelper.GetToList<Stockindetail>(sql);
        }
        //添加入库审核
        public int Add(Stockindetail m)
        {
            string sql = string.Format("insert into Stockindetail values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", m.StockInId, m.Status, m.PlanInQty, m.ActInQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate,m.ModifiedBy,m.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //修改反填
        public Stockindetail Find(int id)
        {
            string sql = "select * from Stockindetail where StockInDetailId=" + id;
            return DBHelper.GetToList<Stockindetail>(sql).FirstOrDefault();
        }
        //修改
        public int Upt(Stockindetail m)
        {
            string sql = string.Format("update Stockindetail set PlanInQty='{0}',ActInQty='{1}',StoragerackId='{2}',AuditinId='{3}',AuditinTime='{4}',Remark='{5}',CreateBy='{6}',CreateDate='{7}',ModifiedBy='{8}',ModifiedDate='{9}' where StockInDetailId={10}", m.PlanInQty, m.ActInQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate,m.StockInDetailId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除
        public int Del(int id)
        {
            string sql = "delete from Stockindetail where StockInDetailId=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
