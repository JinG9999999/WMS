using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StockindetailsController : ControllerBase
    {
        StockindetailDAL dal = new StockindetailDAL();
        // GET: api/Stockindetails
        [HttpGet]
        public List<Stockindetail> Gets()
        {
            return dal.Show();
        }

        // GET: api/Stockindetails/5
        [HttpGet("{id}", Name = "Get1")]
        public Stockindetail Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Stockindetails
        [HttpPost]
        public int Post([FromBody] Stockindetail m)
        {
            m.Status = false;
            m.CreateDate = DateTime.Now;
            return dal.Add(m);
        }

        // PUT: api/Stockindetails/5
        [HttpPut("{id}")]
        public int Put([FromBody] Stockindetail m)
        {
            m.Status = false;
            m.CreateDate = DateTime.Now;
            return dal.Upt(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return dal.Del(id);
        }
    }
}
