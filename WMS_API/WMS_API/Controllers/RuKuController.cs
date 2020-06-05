using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using DAL;
using Microsoft.AspNetCore.Cors;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class RuKuController : ControllerBase
    {
        ShenheDAL dal = new ShenheDAL();
        // GET: api/RuKu
        [HttpGet]
        public IEnumerable<string> Gets()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RuKu/5
        [HttpGet("{id}", Name = "Get7")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RuKu
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/RuKu/5
        [HttpPost]
        public int Puts([FromBody] Values m)
        {
            m.times = DateTime.Now;
            if (dal.Uptss(m) == 0)
            {
                return 0;
            }
            dal.Upts(m);
            return dal.Uptss(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    

}
