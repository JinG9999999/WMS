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
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        WarehouseDAL warehouseDAL = new WarehouseDAL();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Warehouse> ShowWarehouse()
        {
            return warehouseDAL.ShowWarehouse();
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
