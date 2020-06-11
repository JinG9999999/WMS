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
    public class CarrierDelController : ControllerBase
    {
        CarrierDal dal = new CarrierDal();
        // GET: api/<CarrierDelController>
        [HttpGet]
        public IEnumerable<Carrier> Get()
        {
            return dal.DelShow();
        }

        // GET api/<CarrierDelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarrierDelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarrierDelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarrierDelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
