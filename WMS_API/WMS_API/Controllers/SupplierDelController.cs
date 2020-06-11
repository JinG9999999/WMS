using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using DAL;
using dal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierDelController : ControllerBase
    {
        SupplierDal dal = new SupplierDal();
        // GET: api/<SupplierDelController>
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return dal.DelShow();
        }

        // GET api/<SupplierDelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierDelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierDelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierDelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
