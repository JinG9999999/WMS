using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using DAL;
using dal;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        CarrierDal dal = new CarrierDal();

        private readonly ILogger<Carrier> _logger;

        public CarrierController(ILogger<Carrier> logger)
        {
            _logger = logger;
        }

        //显示承运商
        // GET: api/<CarrierController>
        [HttpGet]
        public PageCarrier CarrierShow(string Name,  Nullable<DateTime> time1, Nullable<DateTime> time2, int PageSize = 5, int CurrentPage = 1)
        {
            var list = dal.CarrierShow();

            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (Name!=null)
            {
                list = list.Where(s => s.CarrierName.Contains(Name)).ToList();
            }


            PageCarrier ps = new PageCarrier();//实例化

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
            ps.Carriers = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        //详情
        // GET api/<CarrierController>/5
        [HttpGet("{id}")]
        public Carrier Get(int id)
        {
            return dal.Find(id);
        }

        //新增承运商
        // POST api/<CarrierController>
        [HttpPost]
        public int Post(Carrier c)
        {
            _logger.LogInformation(c.ModifiedBy + $"新增承运商数据完成，新增承运商编号为{ c.CarrierId}");
            return dal.AddCarrier(c);
        }

        //修改承运商信息
        // PUT api/<CarrierController>/5
        [HttpPut("{id}")]
        public int Put(Carrier c)
        {

            _logger.LogInformation(c.ModifiedBy+$"修改承运商数据完成，修改承运商编号为{ c.CarrierId}");
            return dal.UptCarrier(c);
        }

        //修改承运商状态为已删除
        // DELETE api/<CarrierController>/5
        [HttpDelete("{id}")]
        public int Upt(int id,Carrier c)
        {
            
            var name = c.ModifiedBy;
            _logger.LogInformation($"{name}删除承运商数据完成，删除承运商编号为{id}");
            return dal.DelCarrier(c);
        }
    }
}
