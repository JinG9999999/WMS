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
        //实例化
        DeliveryDal dal = new DeliveryDal();
        // GET: api/Inventorymove
        [HttpGet]
        public IEnumerable<Inventorymove> InventorymoveShow()
        {
            return dal.InventorymoveShow();
        }

        // GET: api/Inventorymove/5
        [HttpGet("{id}", Name = "Get")]
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
