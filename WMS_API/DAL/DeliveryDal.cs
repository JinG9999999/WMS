using System;
using System.Collections.Generic;
using Model;

namespace DAL
{
    public class DeliveryDal
    {
        //显示库存记录
        public List<Inventoryrecord> InventoryrecordShow()
        {
            string sql = "select * from Inventoryrecord join Inventory on Inventory.InventoryId = Inventoryrecord.StockInDetailId join Storagerack on Storagerack.ReservoirAreaId = Inventoryrecord.InventoryrecordId";
            return DBHelper.GetToList<Inventoryrecord>(sql);
        }
        //显示发货记录
        public List<Delivery> DeliveryShow()
        {
            string sql = "select * from Delivery d join Stockout s on d.StockOutId=s.StockOutId join Carrier c on d.CarrierId=c.CarrierId";
            return DBHelper.GetToList<Delivery>(sql);
        }
        //显示库存移动
        public List<Inventorymove> InventorymoveShow()
        {
            string sql = "select * from Inventorymove join Storagerack on Storagerack.ReservoirAreaId = Inventorymove.InventorymoveId";
            return DBHelper.GetToList<Inventorymove>(sql);
        }
        //添加库存移动
        public int InventorymoveAdd(Inventorymove Inventorymove)
        {
            string sql = string.Format("insert into Inventorymove values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", Inventorymove.SourceStoragerackId, Inventorymove.AimStoragerackId, Inventorymove.Status, Inventorymove.IsDel, Inventorymove.Remark, Inventorymove.CreateBy, Inventorymove.CreateDate= DateTime.Now, Inventorymove.ModifiedBy,Inventorymove.ModifiedDate=DateTime.Now);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //反填库存移动
        public Inventorymove InventorymoveFind(int id)
        {
            string sql = "select * from Inventorymove join Storagerack on Storagerack.WarehouseId = Inventorymove.InventorymoveId where InventorymoveId=" + id ;
            return DBHelper.GetToList<Inventorymove>(sql)[0];
        }
        //修改库存移动
        public int InventorymoveUpt(Inventorymove Inventorymove)
        {
            string sql = string.Format("update Inventorymove set SourceStoragerackId='{0}',AimStoragerackId='{1}',Status='{2}',IsDel='{3}',Remark='{4}',CreateBy='{5}',CreateDate='{6}',ModifiedBy='{7}',ModifiedDate='{8}' where InventorymoveId='{9}')", Inventorymove.SourceStoragerackId, Inventorymove.AimStoragerackId, Inventorymove.Status, Inventorymove.IsDel, Inventorymove.Remark, Inventorymove.CreateBy, Inventorymove.CreateDate, Inventorymove.ModifiedBy, Inventorymove.ModifiedDate,Inventorymove.InventorymoveId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除库存移动
        public int InventorymoveDel(int id)
        {
            string sql = "delete from Inventorymove where InventorymoveId=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }

    }
}
