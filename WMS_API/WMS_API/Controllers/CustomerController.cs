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
    public class CustomerController : ControllerBase
    {

        CustomerDal dal = new CustomerDal();
        private readonly ILogger<Customer> _logger;

        public CustomerController(ILogger<Customer> logger)
        {
            _logger = logger;
        }
        //显示客户
        // GET: api/<CustomerController>
        [HttpGet]
        public PageCustomer CustomerShow(string Name, Nullable<DateTime> time1, Nullable<DateTime> time2, int PageSize = 5, int CurrentPage = 1)
        {
            var list = dal.CustomerShow();

            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (Name != null)
            {
                list = list.Where(s => s.CustomerName.Contains(Name)).ToList();
            }


            PageCustomer ps = new PageCustomer();//实例化

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
            ps.Customers = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }


        //详情
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return dal.Find(id);
        }

        //新增客户
        // POST api/<CustomerController>
        [HttpPost]
        public int Post(Customer c)
        {
            _logger.LogInformation(c.ModifiedBy + $"新增客户数据完成，新增客户编号为{ c.CustomerId}");
            return dal.AddCustomer(c);
        }

        //修改客户信息
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public int Put(Customer c)
        {
            _logger.LogInformation(c.ModifiedBy + $"修改客户数据完成，修改客户编号为{ c.CustomerId}");
            return dal.UptCustomer(c);
        }


        //修改客户状态为已删除
        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public int UPT(string id)
        {
            _logger.LogInformation($"删除客户数据完成，删除客户编号为{ id}");
            return dal.DelCustomer(id);
        }
    }
}
