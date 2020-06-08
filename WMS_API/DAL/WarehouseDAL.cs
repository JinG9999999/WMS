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
            string str = "select w.WarehouseId WarehouseId,w.WarehouseName WarehouseName,w.Remark Remark,w.CreateBy CreateBy,u.UserNickname UserNickname,w.CreateDate CreateDate, w.ModifiedBy ModifiedBy,u.UserNickname UserNickname2, w.ModifiedDate ModifiedDate from Warehouse w join UserInfo u on u.UserId=w.CreateBy join UserInfo u1 on u1.UserId=w.ModifiedBy";
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
            string str = $"delete from Warehouse where WarehouseId in(" + id + ")";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 查询单条
        /// </summary>
        /// <returns></returns>
        public Warehouse Find(int id)
        {
            string str = "select * from Warehouse w join UserInfo u on u.UserId=w.CreateBy join UserInfo u1 on u1.UserId=w.ModifiedBy where WarehouseId="+id;
            return DBHelper.GetToList<Warehouse>(str)[0];
        }
    }
}
