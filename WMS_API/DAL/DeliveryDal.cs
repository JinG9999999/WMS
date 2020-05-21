using System;
using System.Collections.Generic;
using WMS_API.Models;

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
            string sql = "select Stockout.OrderNo,Delivery.TrackingNo,DeliveryDate,Carrier.CarrierName,Carrier.CarrierPerson,Carrier.Tel,Carrier.Remark,Carrier.CreateBy,Carrier.CreateDate,Carrier.ModifiedBy,Carrier.ModifiedDate from Delivery join Stockout on Delivery.StockOutId = Stockout.StockOutId join Carrier on Carrier.CarrierId = Delivery.CarrierId";
            return DBHelper.GetToList<Delivery>(sql);
        }
        //显示库存移动
        public List<Inventorymove> InventorymoveShow()
        {
            string sql = "select Inventorymove.InventorymoveId,Storagerack.StorageRackName,Inventorymove.Status,Inventorymove.Remark,Inventorymove.CreateBy,Inventorymove.CreateDate,Inventorymove.ModifiedBy,Inventorymove.ModifiedDate from Inventorymove join Storagerack on Storagerack.WarehouseId = Inventorymove.InventorymoveId";
            return DBHelper.GetToList<Inventorymove>(sql);
        }
    }
}
