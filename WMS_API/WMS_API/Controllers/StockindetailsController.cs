using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StockindetailsController : ControllerBase
    {
        StockindetailDAL dal = new StockindetailDAL();
        // GET: api/Stockindetails
        [HttpGet]
        public List<Stockindetail> Gets(int StockInIds)
        {
            return dal.Show().Where(s => s.StockInId == StockInIds).ToList();
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
            m.Status = 1;
            m.CreateDate = DateTime.Now;
            return dal.Add(m);
        }

        // PUT: api/Stockindetails/5
        [HttpPost]
        public int Puts(Stockindetail m)
        {
            m.Status = 1;
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
