﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class StockinDAL
    {
        //显示入库库存列表
        public List<Stockin> Show()
        {
            string sql = "select * from Stockin";
            return DBHelper.GetToList<Stockin>(sql);
        }
        //添加入库库存
        public int Add(Stockin m)
        {
            string sql = string.Format("insert into Stockin values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", m.StockInType, m.SupplierId, m.OrderNo, m.StockInStatus, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //修改反填
        public Stockin Find(int id)
        {
            string sql = "select * from Stockin where StockInId=" + id;
            return DBHelper.GetToList<Stockin>(sql).FirstOrDefault();
        }
        //修改
        public int Upt(Stockin m)
        {
            string sql = string.Format("update Stockin set SupplierId='{0}',OrderNo='{1}',StockInStatus='{2}',Remark='{3}',CreateBy='{4}',CreateDate='{5}',ModifiedBy='{6}',ModifiedDate='{7}' where StockInId={8}", m.SupplierId, m.OrderNo, m.StockInStatus, m.Remark, m.CreateBy, m.CreateDate, m.ModifiedBy, m.ModifiedDate, m.StockInId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除
        public int Del(int id)
        {
            string sql = "delete from Stockin where StockInId=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
