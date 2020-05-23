using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using Microsoft.AspNetCore.Cors;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]//显 示 库 存 记 录
    public class InventoryrecordController : ControllerBase
    {
        //实 例 化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Inventoryrecord
        [HttpGet]
        public PageInventoryrecord InventoryrecordShow(int PageSize, Nullable<DateTime> time1, Nullable<DateTime> time2, int type = 0, int CurrentPage = 1)
        {
            var list = dal.InventoryrecordShow();

            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (type != 0)
            {
                list = list.Where(s => s.StockInDetailId == type).ToList();
            }

            PageInventoryrecord ps = new PageInventoryrecord();//实例化

            ps.TotalCount = list.Count();//总记录数

            if (ps.TotalCount % PageSize == 0)//计算总页数
            {
                ps.TotalPage = ps.TotalCount / PageSize;
            }
            else
            {
                ps.TotalPage = (ps.TotalCount / PageSize) + 1;
            }

            //纠正index页
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > ps.TotalPage)
            {
                CurrentPage = ps.TotalPage;
            }
            //赋值index为当前页
            ps.CurrentPage = CurrentPage;
            //linq查询
            ps.Inventoryrecords = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        // GET: api/Inventoryrecord/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Inventoryrecord
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inventoryrecord/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
