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
    [ApiController]//显示库存记录
    public class InventoryrecordController : ControllerBase
    {
        //实 例 化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Inventoryrecord
        [HttpGet]
        public IEnumerable<Inventoryrecord> InventoryrecordShow()
        {
            return dal.InventoryrecordShow();
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
