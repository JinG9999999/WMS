using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class StoragerackDAL
    {
        /// <summary>
        /// 查看所有货架
        /// </summary>
        /// <returns></returns>
        public List<Storagerack> ShowStoragerack()
        {
            string str = "select * from Storagerack s join Reservoirarea r on s.ReservoirAreaId=r. ReservoirAreaId join Warehouse w on r.WarehouseId=w.WarehouseId";
            return DBHelper.GetToList<Storagerack>(str);
        }
        /// <summary>
        /// 添加新货架
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddStoragerack(Storagerack sRack)
        {
            string str = $"insert into Storagerack values('{sRack.StorageRackName}',{sRack.ReservoirAreaId},0,'{sRack.Remark}',1,GETDATE(),1,GETDATE())";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 修改货架信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>

        public int AlterStoragerack(Storagerack  sRack)
        {
            string str = $"update Storagerack set StorageRackName='{sRack.StorageRackName}',ReservoirAreaId='{sRack.ReservoirAreaId}',Remark='{sRack.Remark}' where StorageRackId={sRack.StorageRackId}";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 删除货架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelStoragerack(string id)
        {
            string str = $"update Storagerack set IsDel=1 where StoragerackId in(" + id + ")";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
