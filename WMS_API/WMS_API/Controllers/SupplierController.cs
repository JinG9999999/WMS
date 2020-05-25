using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using dal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        SupplierDal dal = new SupplierDal();

        //显示供应商
        // GET: api/<SupplierController>
        [HttpGet]
        public PageSupplier SupplierShow(string Name, int PageSize, Nullable<DateTime> time1, Nullable<DateTime> time2, int CurrentPage = 1)
        {
            var list = dal.SupplierShow();

            if (time1 != null && time2 != null)
            {
                list = list.Where(s => s.CreateDate >= time1 && s.CreateDate <= time2).ToList();
            }
            if (Name != "")
            {
                list = list.Where(s => s.SupplierName.Contains(Name)).ToList();
            }


            PageSupplier ps = new PageSupplier();//实例化

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
            ps.Suppliers = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        //详情
        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return dal.Find(id);
        }


        //新增供应商
        // POST api/<SupplierController>
        [HttpPost]
        public int Post(Supplier s)
        {
            return dal.AddSupplier(s);
        }


        //修改供应商信息
        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public int Put(Supplier s)
        {
            return dal.UptSupplier(s);
        }


        //修改供应商状态为已删除
        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public int UPT(int id)
        {
            return dal.DelSupplier(id);
        }
    }
}
