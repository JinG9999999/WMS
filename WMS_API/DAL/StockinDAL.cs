using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Model;
using ServiceStack;

namespace DAL
{
    public class StockinDAL
    {
        static SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=WMS;Integrated Security=True");
        public PageStu Show(Stockin person,int CurrentPage=1,int PageSize=10)
        {
            using (IDbConnection connection = new SqlConnection(conn.ConnectionString))
            {
                var sql = @"select * from Stockin where StockInStatus=" + person.StockInStatus;
                if (person.StockInType!="")
                {
                    sql += " and StockInType=@stockInType";
                }
                if (person.CreateDate!="" && person.ModifiedDate!="")
                {
                    sql += "and CreateDate>=@createDate and ModifiedDate<=@modifiedDate";
                }
                
                var list= connection.Query<Stockin>(sql,new { stockInType=person.StockInType, createDate=person.CreateDate, modifiedDate=person.ModifiedDate }).ToList();
                PageStu ps = new PageStu();//实例化

                ps.TotalCount = list.Count();//总记录数

                if (ps.TotalCount % PageSize == 0)//计算总页数
                {
                    ps.TotalPage = ps.TotalCount / PageSize;
                }
                else
                {
                    ps.TotalPage = (ps.TotalCount / PageSize) + 1;
                }
                //纠正index页
                if (CurrentPage < 1)
                {
                    CurrentPage = 1;
                }
                if (CurrentPage > ps.TotalPage)
                {
                    CurrentPage = ps.TotalPage;
                }
                //赋值index为当前页
                ps.CurrentPage = CurrentPage;
                //linq查询
                ps.stockins = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
                return ps;
            }
        }
        //显示入库库存列表
        //public List<Stockin> Show()
        //{
        //    string sql = "select * from Stockin";
        //    return DBHelper.GetToList<Stockin>(sql);
        //}
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
