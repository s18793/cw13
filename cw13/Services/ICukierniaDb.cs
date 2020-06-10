using cw13.DTOs.resp;
using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public interface ICukierniaDb
    {

        public IEnumerable<OrderRespon> getOrders(String nazwisko);

    }
}
