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
        public IEnumerable<Reservoirarea> ShowReservoirarea()
        {
            return reservoirareaDAL.ShowReservoirarea();
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
