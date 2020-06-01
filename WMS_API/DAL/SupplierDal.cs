using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace dal
{
   public class SupplierDal
    {
        //显示供应商
        public List<Supplier> SupplierShow()
        {
            string str = "select * from Supplier s join UserInfo u on s.CreateBy=u.UserId where c.IsDel=0";
            
            return DBHelper.GetToList<Supplier>(str);
        }
        //反填供应商
        public Supplier Find(int id)
        {
            string str = $"select * from Supplier s join UserInfo u on s.CreateBy=u.UserId where c.SupplierId={id}";

            return DBHelper.GetToList<Supplier>(str)[0];
        }

        //修改供应商(删除操作)
        public int DelSupplier(int id)
        {
            string str = $"update Supplier set IsDel=1 where SupplierId={id}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //修改供应商信息
        public int UptSupplier(Supplier s)
        {
            string str = $"update Supplier set SupplierName='{s.SupplierName}',[Address]='{s.Address}',Tel='{s.Tel}',SupplierPerson='{s.SupplierPerson}',Email='{s.Email}',Remark='{s.Remark}',ModifiedBy={s.ModifiedBy},ModifiedDate=GETDATE() where SupplierId={s.SupplierId}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //新增供应商
        public int AddSupplier(Supplier s)
        {
            string str = $"insert into Supplier values('{s.SupplierName}','{s.Address}','{s.Tel}','{s.SupplierPerson}',{s.SupplierLevel},'{s.Email}',{s.IsDel},'{s.Remark}',{s.CreateBy},getdate(),null,null)";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
