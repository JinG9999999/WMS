using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;

namespace WMS_API.Controllers
{
    [EnableCors("wms")]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class ReservoirareaController : ControllerBase
    {
        ReservoirareaDAL reservoirareaDAL = new ReservoirareaDAL();
        /// <summary>
        /// 显示全部库区
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PageReservoirarea ShowReservoirarea( Nullable<DateTime> time1, Nullable<DateTime> time2, int CurrentPage = 1)
        {
            var list = reservoirareaDAL.ShowReservoirarea();
            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            PageReservoirarea ps = new PageReservoirarea();//实例化

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
            ps.reservoirareas = list.Skip(10 * (CurrentPage - 1)).Take(10).ToList();
            return ps;
           
        }

        //// GET: api/Reservoirarea/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// 添加库区
        /// </summary>
        /// <param name="reservoirarea"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostReservoirarea([FromBody] Reservoirarea  reservoirarea)
        {
            return new JsonResult(reservoirareaDAL.AddReservoirarea(reservoirarea));
        }

        /// <summary>
        /// 修改库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public IActionResult PutReservoirarea([FromBody] Reservoirarea reservoirarea)
        {
            return new JsonResult(reservoirareaDAL.AlterReservoirarea(reservoirarea));
        }

        /// <summary>
        /// 删除库区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteReservoirarea(string id)
        {
            int ret = reservoirareaDAL.DelReservoirarea(id);
            return new JsonResult(ret);
        }
    }
}
