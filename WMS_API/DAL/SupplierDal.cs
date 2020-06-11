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
            string str = "select * from Supplier  where IsDel=0";

            return DBHelper.GetToList<Supplier>(str);
        }
        //反填供应商
        public Supplier Find(int id)
        {
            string str = $"select * from Supplier  where SupplierId={id}";

            return DBHelper.GetToList<Supplier>(str)[0];
        }

        //修改供应商(删除操作)
        public int DelSupplier(Supplier s)
        {
            string str = $"update Supplier set IsDel=1 ,ModifiedBy='{s.ModifiedBy}', ModifiedDate=getdate() where SupplierId in ({s.SupplierId})";
            return DBHelper.ExecuteNonQuery(str);
        }

        //修改供应商信息
        public int UptSupplier(Supplier s)
        {
            string str = $"update Supplier set SupplierName='{s.SupplierName}',[Address]='{s.Address}',Tel='{s.Tel}',SupplierPerson='{s.SupplierPerson}',Email='{s.Email}',Remark='{s.Remark}',ModifiedBy='{s.ModifiedBy}',ModifiedDate=GETDATE() where SupplierId={s.SupplierId}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //新增供应商
        public int AddSupplier(Supplier s)
        {
            string str = $"insert into Supplier values('{s.SupplierName}','{s.Address}','{s.Tel}','{s.SupplierPerson}',{s.SupplierLevel},'{s.Email}',0,'{s.Remark}','{s.ModifiedBy}',getdate(),'{s.ModifiedBy}',getdate())";
            return DBHelper.ExecuteNonQuery(str);
        }

        //查看删除记录
        public List<Supplier> DelShow()
        {
            string str = "select * from Supplier where IsDel=1";
            return DBHelper.GetToList<Supplier>(str);
        }
    }
}
