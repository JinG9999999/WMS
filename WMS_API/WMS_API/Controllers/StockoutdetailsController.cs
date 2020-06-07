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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockoutdetailsController : ControllerBase
    {
        StockoutdetailDAL dal = new StockoutdetailDAL();
        // GET: api/Stockouts
        [HttpGet]
        public List<StockoutDetail> Gets(int StockoutIds)
        {
            return dal.Show().Where(s => s.StockOutId == StockoutIds).ToList();
        }

        // GET: api/Stockouts/5
        [HttpGet("{id}", Name = "Get3")]
        public StockoutDetail Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Stockouts
        [HttpPost]
        public int Post([FromBody] StockoutDetail m)
        {
            m.Status = 0;
            m.CreateDate = DateTime.Now;
            return dal.Add(m);
        }

        // PUT: api/Stockouts/5
        [HttpPost]
        public int Putss(StockoutDetail stockoutDetail)
        {
            stockoutDetail.CreateDate = DateTime.Now;

            return dal.Upt(stockoutDetail);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public int Delete(int id)
        {
            return dal.Del(id);
        }
    }
}
