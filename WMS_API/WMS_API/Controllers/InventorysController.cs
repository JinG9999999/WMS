using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventorysController : ControllerBase
    {
        InventoryDAL dal = new InventoryDAL();
        // GET: api/Inventorys
        [HttpGet]
        public List<Inventory> Get()
        {
            return dal.Show();
        }

        // GET: api/Inventorys/5
        //[HttpGet("{id}", Name = "Get4")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Inventorys
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inventorys/5
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
