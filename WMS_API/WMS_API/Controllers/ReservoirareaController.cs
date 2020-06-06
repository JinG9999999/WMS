using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;

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

        public PageReservoirarea ShowReservoirarea(/* Nullable<DateTime> time1, Nullable<DateTime> time2,*/ string name = "", int wid = 0, int CurrentPage = 1, int Pagesize = 5)
        {
            var list = reservoirareaDAL.ShowReservoirarea();
            //if (time1 != null && time2 != null)
            //{
            //    list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            //}
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(s => s.ReservoirAreaName.Contains(name)).ToList();
            }
            if (wid != 0)
            {
                list = list.Where(s => s.WarehouseId == wid).ToList();
            }

            PageReservoirarea ps = new PageReservoirarea();//实例化

            ps.totalCount = list.Count();//总记录数

            if (ps.totalCount % Pagesize == 0)//计算总页数
            {
                ps.totalPage = ps.totalCount / Pagesize;
            }
            else
            {
                ps.totalPage = (ps.totalCount / Pagesize) + 1;
            }
            //纠正index页
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > ps.totalPage)
            {
                CurrentPage = ps.totalPage;
            }
            //赋值index为当前页
            ps.currentPage = CurrentPage;
            //linq查询
            ps.reservoirareas = list.Skip(Pagesize * (CurrentPage - 1)).Take(Pagesize).ToList();
            return ps;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public List<Warehouse> BandSelWarehouse()
        //{
        //    return reservoirareaDAL.BandSelWarehouse();
        //}
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
        public IActionResult PostReservoirarea([FromBody] Reservoirarea reservoirarea)
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
