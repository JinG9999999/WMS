using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class WarehouseDAL
    {
        /// <summary>
        /// 查看所有仓库
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> ShowWarehouse()
        {
            string str = "select * from Warehouse join UserInfo on UserInfo.UserId=Warehouse.CreateBy";
            return DBHelper.GetToList<Warehouse>(str);
        }
        /// <summary>
        /// 添加新仓库
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// 
        public int AddWarehouse(Warehouse  wHouse)
        {
            string str = $"insert into Warehouse values('{wHouse.WarehouseName}',0,'{wHouse.Remark}',1,GETDATE(),1,GETDATE())";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 修改仓库信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>

        public int AlterWarehouse(Warehouse wHouse)
        {
            string str = $"update Warehouse set WarehouseName='{wHouse.WarehouseName}',Remark='{wHouse.Remark}' where WarehouseId={wHouse.WarehouseId}";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelWarehouse(string id)
        {
            string str = $"update Warehouse set IsDel=1 where WarehouseId in(" + id + ")";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
