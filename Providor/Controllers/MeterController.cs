using Microsoft.AspNetCore.Mvc;
using Providor.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Providor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        private readonly IMeterService _meterService;
        public MeterController(IMeterService meterService)
        {
            _meterService = meterService;
        }

        // GET: api/<MeterController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _meterService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<MeterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
