using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using WMS_API.Models;

namespace DAL
{
    public class StockoutDAL
    {
        //显示出库库存列表
        public List<Stockout> Show()
        {
            string sql = "select * from Stockout";
            return DBHelper.GetToList<Stockout>(sql);
        }
        //添加出库库存
        public int Add(Stockout m)
        {
            string sql = string.Format("insert into Stockout values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", m.OrderNo, m.StockOutType, m.CustomerId, m.StockOutStatus, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //修改反填
        public Stockout Find(int id)
        {
            string sql = "select * from Stockout where StockOutId=" + id;
            return DBHelper.GetToList<Stockout>(sql).FirstOrDefault();
        }
        //修改
        public int Upt(Stockout m)
        {
            string sql = string.Format("update Stockin set OrderNo='{0}',StockOutType='{1}',CustomerId='{2}',StockOutStatus='{3}',Remark='{4}',CreateBy='{5}',CreateDate='{6}',ModifiedBy='{7}',ModifiedDate='{8}' where StockOutId={9}", m.OrderNo, m.StockOutType, m.CustomerId, m.StockOutStatus, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate, m.StockOutId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除
        public int Del(int id)
        {
            string sql = "delete from Stockout where StockOutId=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
