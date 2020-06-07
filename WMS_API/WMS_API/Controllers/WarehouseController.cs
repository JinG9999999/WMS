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
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        WarehouseDAL warehouseDAL = new WarehouseDAL();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageWarehouse ShowWarehouse( Nullable<DateTime> time1, Nullable<DateTime> time2, int CurrentPage = 1)
        {
            var list = warehouseDAL.ShowWarehouse();
            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            PageWarehouse ps = new PageWarehouse();//实例化

            ps.TotalCount = list.Count();//总记录数

            if (ps.TotalCount % 10 == 0)//计算总页数
            {
                ps.TotalPage = ps.TotalCount / 10;
            }
            else
            {
                ps.TotalPage = (ps.TotalCount / 10) + 1;
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
            ps.warehouses = list.Skip(10 * (CurrentPage - 1)).Take(10).ToList();
            return ps;
        }

        //// GET: api/Warehouse/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult PostWarehouse([FromBody] Warehouse warehouse)
        {
            return new JsonResult(warehouseDAL.AddWarehouse(warehouse));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public IActionResult PutWarehouse([FromBody] Warehouse  warehouse)
        {
            return new JsonResult(warehouseDAL.AlterWarehouse(warehouse));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteWarehouse(string id)
        {
            int ret = warehouseDAL.DelWarehouse(id);
            return new JsonResult(ret);
        }
    }
}
