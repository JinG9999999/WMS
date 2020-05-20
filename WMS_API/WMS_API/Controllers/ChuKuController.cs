using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DAL;

namespace WMS_API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ChuKuController : ControllerBase
    {
        ShenheDAL dal=new ShenheDAL();
        // GET: api/ChuKu
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ChuKu/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ChuKu
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ChuKu/5
        [HttpPut("{id}")]
        public int Put([FromBody] int id, string name, Nullable<DateTime> times)
        {
                   dal.Upte(id, name, times);
            return dal.Uptee(id, name, times);
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
