using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using WMS_API.Models;

namespace DAL
{
    public class StockindetailDAL
    {
        //显示入库审核列表
        public List<Stockindetail> Show()
        {
            string sql = "select * from Stockin";
            return DBHelper.GetToList<Stockindetail>(sql);
        }
        //添加入库审核
        public int Add(Stockindetail m)
        {
            string sql = string.Format("insert into Stockin values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", m.StockInId, m.Status, m.PlanInQty, m.ActInQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate,m.ModifiedBy,m.ModifiedDate);
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
            string sql = string.Format("update Stockin set StockInId='{0}',Status='{1}',PlanInQty='{2}',ActInQty='{3}',StoragerackId='{4}',AuditinId='{5}',AuditinTime='{6}',Remark='{7}',CreateBy='{8}',CreateDate='{9}',ModifiedBy='{10}',ModifiedDate='{11}' where StockInDetailId={12})", m.StockInId, m.Status, m.PlanInQty, m.ActInQty, m.StoragerackId, m.AuditinId, m.AuditinTime, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate,m.StockInDetailId);
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
