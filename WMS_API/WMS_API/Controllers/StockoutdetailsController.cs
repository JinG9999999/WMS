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
    [Route("api/[controller]")]
    [ApiController]
    public class StockoutdetailsController : ControllerBase
    {
        StockoutdetailDAL dal = new StockoutdetailDAL();
        // GET: api/Stockouts
        [HttpGet]
        public List<Stockoutdetail> Gets()
        {
            return dal.Show();
        }

        // GET: api/Stockouts/5
        [HttpGet("{id}", Name = "Get3")]
        public Stockoutdetail Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Stockouts
        [HttpPost]
        public int Post([FromBody] Stockoutdetail m)
        {
            m.Status = false;
            m.CreateDate = DateTime.Now;
            return dal.Add(m);
        }

        // PUT: api/Stockouts/5
        [HttpPut("{id}")]
        public int Put([FromBody] Stockoutdetail m)
        {
            m.Status = false;
            m.CreateDate = DateTime.Now;
            return dal.Upt(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public int Delete(int id)
        {
            return dal.Del(id);
        }
    }
}
