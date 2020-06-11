using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw13.Controllers
{
    public class CukierniaController : ControllerBase


    {

        private readonly ICukierniaDb ic;


        public CukierniaController(ICukierniaDb dv)
        {
            ic = dv;
        }
        [HttpGet]
        public IActionResult getOrders(String nazwisko)
        {
            var order = ic.getOrders(nazwisko);
            return Ok(order);
        }
    }
}