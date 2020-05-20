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
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StockinsController : ControllerBase
    {
        StockinDAL dal = new StockinDAL();
        // GET: api/Stockins
        [HttpGet]
        public List<Stockin> Gets()
        {
            return dal.Show();
        }

        // GET: api/Stockins/5
        [HttpGet("{id}", Name = "Get")]
        public Stockin Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Stockins
        [HttpPost]
        public IActionResult Post([FromBody] Stockin m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = Convert.ToInt32(rdn.Next(99999999).ToString().PadLeft(8, '0'));
            m.StockInStatus = false;
            m.CreateDate = DateTime.Now;
            return new JsonResult(dal.Add(m));
        }

        // PUT: api/Stockins/5
        [HttpPut("{id}")]
        public int Put([FromBody] Stockin m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = Convert.ToInt32(rdn.Next(99999999).ToString().PadLeft(8, '0'));
            m.StockInStatus = false;
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
