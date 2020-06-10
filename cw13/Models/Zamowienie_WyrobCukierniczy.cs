using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobu { get; set; }

        public int IdZamowienia { get; set; }

        public int Ilosc { get; set; }

        [MaxLength(100)]
        public string? Uwagi { get; set; }
    }
}
