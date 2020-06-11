using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using Microsoft.AspNetCore.Cors;
using StackExchange.Redis;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StockinsController : ControllerBase
    {
        private readonly IDatabase _redis;
        public StockinsController(RedisHelper client)
        {
            _redis = client.GetDatabase();
        }

        StockinDAL dal = new StockinDAL();
        // GET: api/Stockins
        [HttpPost]
        public PageStu Gets(Stockin person)
        {
            return dal.Show(person);
        }

        // GET: api/Stockins/5
        [HttpGet("{id}", Name = "Get11")]
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
            m.StockInStatus = 0;
            m.CreateDate = DateTime.Now.ToString();
            //存放数据
            _redis.StringSet("Adds", dal.Add(m));
            //取出数据
            var Addss = _redis.StringGet("Adds");
            return new JsonResult(Addss);
        }

        // PUT: api/Stockins/5
        [HttpPost]
        public int Puts(Stockin m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = Convert.ToInt32(rdn.Next(99999999).ToString().PadLeft(8, '0'));
            m.CreateDate = DateTime.Now.ToString();
            return dal.Upt(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public int Delete(int id)
        {
            return dal.Del(id);
            //int t = 0;
            //id = id.Substring(0, id.Length - 1);//删除字符串最后一个字符
            //string[] datalist = id.Split(',');
            //foreach (var item in datalist)
            //{
            //    int daa = int.Parse(item);
            //    //调用删除方法
            //    t = t + dal.Del(daa);
            //}
            //return t;
        }
    }
}
