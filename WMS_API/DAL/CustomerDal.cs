using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace dal
{
  public  class CustomerDal
    {
        //显示客户
        public List<Customer> CarrierShow()
        {
            string str = "select * from Customer c join UserInfo u on c.CreateBy=u.CreateBy where c.IsDel=0";
            
            return DBHelper.GetToList<Customer>(str);
        }

        //修改客户(删除操作)
        public int DelCarrier(int id)
        {
            string str = $"update Customer set IsDel=1 where CustomerId={id}";
            return DBHelper.ExecuteNonQuery(str);
        }


        //修改客户信息
        public int UptCarrier(Customer c)
        {
            string str = $"update Customer set CustomerName='{c.CustomerName}',[Address]='{c.Address}',Tel='{c.Tel}',CarrierPerson='{c.CarrierPerson}',Email='{c.Email}',Remark='{c.Remark}',ModifiedBy={c.ModifiedBy},ModifiedDate=GETDATE() where CustomerId={c.CustomerId}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //新增客户
        public int AddCarrier(Customer c)
        {
            string str = $"insert into Customer values('{c.CustomerName}','{c.Address}','{c.Tel}','{c.CarrierPerson}',{c.CarrierLevel},'{c.Email}',{c.IsDel},'{c.Remark}',{c.CreateBy},getdate(),null,null)";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
