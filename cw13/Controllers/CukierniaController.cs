using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw13.Controllers
{

    [ApiController]
    public class CukierniaController : ControllerBase


    {

        private readonly ICukierniaDb ic;

        
        public CukierniaController(ICukierniaDb dv)
        {
            ic = dv;
        }
        [HttpGet]
        [Route("api/orders")]
        public IActionResult getOrders(string nazwisko)
        {
            var order = ic.getOrders(nazwisko);
            return Ok(order);
        }
    }
}