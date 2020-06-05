using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using Microsoft.AspNetCore.Cors;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class StoragerackController : ControllerBase
    {
        StoragerackDAL storagerackDAL = new StoragerackDAL();
        /// <summary>
        /// 显示所有货架
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageStoragerack ShowStoragerack(Nullable<DateTime> time1, Nullable<DateTime> time2, int CurrentPage = 1)
        {
            var list = storagerackDAL.ShowStoragerack();
            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            PageStoragerack ps = new PageStoragerack();//实例化

            ps.TotalCount = list.Count();//总记录数

            if (ps.TotalCount % 10 == 0)//计算总页数
            {
                ps.TotalPage = ps.TotalCount / 10;
            }
            else
            {
                ps.TotalPage = (ps.TotalCount / 10) + 1;
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
            ps.storageracks = list.Skip(10 * (CurrentPage - 1)).Take(10).ToList();
            return ps;

        }

        //// GET: api/Storagerack/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// 添加新货架
        /// </summary>
        /// <param name="storagerack"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostStoragerack([FromBody] Storagerack  storagerack)
        {
            return new JsonResult(storagerackDAL.AddStoragerack(storagerack));
        }

        /// <summary>
        /// 修改货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public IActionResult PutStoragerack([FromBody] Storagerack  storagerack)
        {
            return new JsonResult(storagerackDAL.AlterStoragerack(storagerack));
        }

        /// <summary>
        /// 删除货架
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteStoragerack(string id)
        {
            int ret = storagerackDAL.DelStoragerack(id);
            return new JsonResult(ret);
        }
    }
}
