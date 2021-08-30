using Microsoft.AspNetCore.Mvc;
using Providor.Business.Exceptions;
using Providor.Business.Services;
using System;
using System.Net;

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
            catch (EmptyResultException)
            {
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);

            }
        }
    }
}
