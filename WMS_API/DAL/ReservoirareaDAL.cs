using Microsoft.AspNetCore.Mvc;
using System;
using Model;
using System.Collections.Generic;

namespace DAL
{
    public class ReservoirareaDAL
    {
         /// <summary>
         /// 查看所有库区
         /// </summary>
         /// <returns></returns>
        public List<Reservoirarea> ShowReservoirarea()
        {
            string str = "select * from Reservoirarea r join Warehouse w on w.WarehouseId =r.WarehouseId";
            return DBHelper.GetToList<Reservoirarea>(str);
        }
        /// <summary>
        /// 添加新库区
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddReservoirarea(Reservoirarea rArea)
        {
            string str = $"insert into Reservoirarea values('{rArea.ReservoirAreaName}',{rArea.WarehouseId},0,'{rArea.Remark}','{rArea.CreateBy}',GETDATE(),'{rArea.ModifiedBy}',GETDATE())";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 修改库区信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AlterReservoirarea(Reservoirarea  rArea)
        {
            string str = $"update Reservoirarea set ReservoirAreaName='{rArea.ReservoirAreaName}',WarehouseId='{rArea.WarehouseId}',Remark='{rArea.Remark}' where ReservoirAreaId={rArea.ReservoirAreaId}";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 删除库区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelReservoirarea(string id)
        {
            string str = $"update Reservoirarea set IsDel=1 where ReservoirAreaId in(" + id + ")";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
