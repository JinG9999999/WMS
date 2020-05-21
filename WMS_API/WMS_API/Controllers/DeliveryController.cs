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
    [ApiController]//显示发货记录
    public class DeliveryController : ControllerBase
    {
        //实例化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Delivery
        [HttpGet]
        public IEnumerable<Delivery> Get()
        {
            return dal.DeliveryShow();
        }

        // GET: api/Delivery/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Delivery
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Delivery/5
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
