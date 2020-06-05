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
            string sql = "select InventoryrecordId,Storagerack.StorageRackId,StorageRackName,Inventoryrecord.Qty,Inventoryrecord.Remark,Inventoryrecord.CreateBy,Inventoryrecord.CreateDate,Inventoryrecord.ModifiedBy,Inventoryrecord.ModifiedDate from Inventoryrecord join Inventory on Inventory.InventoryId = Inventoryrecord.StockInDetailId join Storagerack on Storagerack.WarehouseId = Inventoryrecord.InventoryrecordId";
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
            string sql = "select Inventorymove.InventorymoveId,Storagerack.StorageRackName,Inventorymove.Status,Inventorymove.Remark,Inventorymove.CreateBy,Inventorymove.CreateDate,Inventorymove.ModifiedBy,Inventorymove.ModifiedDate from Inventorymove join Storagerack on Storagerack.WarehouseId = Inventorymove.InventorymoveId";
            return DBHelper.GetToList<Inventorymove>(sql);
        }
        //添加库存移动
        public int InventorymoveAdd(Inventorymove Inventorymove)
        {
            string sql = string.Format("insert into Inventorymove values('1','1','1','1','beihzu','1','2020-1-4','1','2020-5-21'))", Inventorymove.SourceStoragerackId, Inventorymove.AimStoragerackId, Inventorymove.Status, Inventorymove.IsDel, Inventorymove.Remark, Inventorymove.CreateBy, Inventorymove.CreateDate, Inventorymove.ModifiedBy,Inventorymove.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //反填库存移动
        public Inventorymove InventorymoveFind(int id)
        {
            string sql = "select Inventorymove.InventorymoveId,Storagerack.StorageRackName,Inventorymove.Status,Inventorymove.Remark,Inventorymove.CreateBy,Inventorymove.CreateDate,Inventorymove.ModifiedBy,Inventorymove.ModifiedDate from Inventorymove join Storagerack on Storagerack.WarehouseId = Inventorymove.InventorymoveId where InventorymoveId=" + id ;
            return DBHelper.GetToList<Inventorymove>(sql)[0];
        }
        //修改库存移动
        public int InventorymoveUpt(Inventorymove Inventorymove)
        {
            string sql = string.Format("update Inventorymove set SourceStoragerackId='1',AimStoragerackId='1',Status='1',IsDel='1',Remark='beihzu',CreateBy='1',CreateDate='2020-1-4',ModifiedBy='1',ModifiedDate='2020-5-21')", Inventorymove.SourceStoragerackId, Inventorymove.AimStoragerackId, Inventorymove.Status, Inventorymove.IsDel, Inventorymove.Remark, Inventorymove.CreateBy, Inventorymove.CreateDate, Inventorymove.ModifiedBy, Inventorymove.ModifiedDate);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //删除库存移动
        public int InventorymoveDel(int id)
        {
            string sql = "delete from Inventorymove where InventorymoveId" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }

    }
}
