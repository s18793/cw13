using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.DTOs.resp
{
    public class OrderRespon
    {
        
        public int IdZamowienia { get; set; }
        public int IdWyrobu { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; } 
        public string Nazwa { get; set; }
        public double CenaZaSzt { get; set; }
        public string Typ { get; set; }
    }
}
