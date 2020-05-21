using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //显示库存移动
    public class InventorymoveController : ControllerBase
    {
        //实例化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Inventorymove
        [HttpGet]
        public IEnumerable<Inventorymove> Get()
        {
            return dal.InventorymoveShow();
        }

        // GET: api/Inventorymove/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Inventorymove
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inventorymove/5
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
