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
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController] //显示库存移动
    public class InventorymoveController : ControllerBase
    {
        //实 例 化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Inventorymove
        [HttpGet]
        public PageInventorymove InventorymoveShow(int PageSize, Nullable<DateTime> time1, Nullable<DateTime> time2, int type = 0, int CurrentPage = 1)
        {
            var list = dal.InventorymoveShow();

            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (type != 0)
            {
                list = list.Where(s => s.SourceStoragerackId == type).ToList();
            }

            PageInventorymove ps = new PageInventorymove();//实例化

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
            ps.Inventorymoves = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        // GET: api/Inventorymove/5
        [HttpGet("{id}", Name = "InventorymoveFind")]
        public Inventorymove InventorymoveFind(int id)
        {
            return dal.InventorymoveFind(id);
        }

        // POST: api/Inventorymove
        [HttpPost]
        public int Post([FromBody] Inventorymove value)
        {
           return  dal.InventorymoveAdd(value);
        }

        // PUT: api/Inventorymove/5
        [HttpPut("{id}")]
        public int Put([FromBody] Inventorymove value)
        {
           return  dal.InventorymoveUpt(value) ;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return dal.InventorymoveDel(id);
        }
    }
}
