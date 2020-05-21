using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;

namespace WMS_API.Controllers
{
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StockinsController : ControllerBase
    {
        StockinDAL dal = new StockinDAL();
        // GET: api/Stockins
        [HttpGet]
        public PageStu Gets(int PageSize,Nullable<DateTime> time1,Nullable<DateTime> time2,string type="",int state=0, int CurrentPage=1)
        {
            var list = dal.Show();
            if (time1!=null && time2!=null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (string.IsNullOrEmpty(type))
            {
                list = list.Where(s => s.StockInType == type).ToList();
            }
            if (state!=0)
            {
                list = list.Where(s =>s.StockInStatus == state).ToList();
            }
            PageStu ps = new PageStu();//实例化

            ps.TotalCount = list.Count();//总记录数

            if (ps.TotalCount % PageSize == 0)//计算总页数
            {
                ps.TotalPage = ps.TotalCount / PageSize;
            }
            else
            {
                ps.TotalPage = (ps.TotalCount / PageSize) + 1;
            }
            //纠正index页
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > ps.TotalPage)
            {
                CurrentPage = ps.TotalPage;
            }
            //赋值index为当前页
            ps.CurrentPage = CurrentPage;
            //linq查询
            ps.stockins = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
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
            m.StockInStatus = 1;
            m.CreateDate = DateTime.Now;
            return new JsonResult(dal.Add(m));
        }

        // PUT: api/Stockins/5
        [HttpPut("{id}")]
        public int Put([FromBody] Stockin m)
        {
            System.Random rdn = new System.Random();
            m.OrderNo = Convert.ToInt32(rdn.Next(99999999).ToString().PadLeft(8, '0'));
            m.StockInStatus = 1;
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
