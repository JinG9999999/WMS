using System;
using System.Collections.Generic;
using System.Text;
using Model;
using WMS_API.Models;

namespace DAL
{
    public class InventoryDAL
    {
        //显示库存查询列表
        public List<Inventory> Show()
        {
            string sql = "select * from Inventory";
            return DBHelper.GetToList<Inventory>(sql);
        }
    }
}
