using Microsoft.AspNetCore.Mvc;
using Providor.Business.Exceptions;
using Providor.Business.Services;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Providor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeterPointController : ControllerBase
    {
        private readonly IMeterPointService _service;
        public MeterPointController(IMeterPointService service)
        {
            _service = service;
        }

        // GET: api/<MeterController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _service.Get();
                return Ok(data);
            }
            catch (EmptyResultException ex)
            {
                return StatusCode(204, ex.Message);
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
