using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS_API.Models;
using DAL;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockoutsController : ControllerBase
    {
        StockoutDAL dal = new StockoutDAL();
        // GET: api/Stockoutdetails
        [HttpGet]
        public List<Stockout> Gets()
        {
            return dal.Show();
        }

        // GET: api/Stockoutdetails/5
        [HttpGet("{id}", Name = "Get2")]
        public Stockout Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Stockoutdetails
        [HttpPost]
        public int Post([FromBody] Stockout m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = rdn.Next(99999999).ToString().PadLeft(8, '0');
            m.StockOutStatus = 1;
            m.CreateDate = DateTime.Now;
            return dal.Add(m);
        }

        // PUT: api/Stockoutdetails/5
        [HttpPut("{id}")]
        public int Put([FromBody] Stockout m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = rdn.Next(99999999).ToString().PadLeft(8, '0');
            m.StockOutStatus = 1;
            m.CreateDate = DateTime.Now;
            return dal.Upt(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            int t = 0;
            id = id.Substring(0, id.Length - 1);//删除字符串最后一个字符
            string[] datalist = id.Split(',');
            foreach (var item in datalist)
            {
                int daa = int.Parse(item);
                //调用删除方法
                t = t + dal.Del(daa);
            }
            return t;
        }
    }
}
