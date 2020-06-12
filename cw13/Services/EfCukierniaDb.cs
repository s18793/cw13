using cw13.DTOs.resp;
using cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Services
{
    public class EfCukierniaDb : ICukierniaDb
    {
        private readonly CukierniaContext _con;

        public EfCukierniaDb(CukierniaContext context)
        {
            _con = context;
        }
        public IEnumerable<OrderRespon> getOrders(string nazwisko)
        {
            var klient = _con.Klients.FirstOrDefault(e => e.Nazwisko == nazwisko);

            if (nazwisko == null)
            {
                var find = from Zamowienie_WyrobCukierniczy in _con.Zamowienia_WyrobCukiernicze
                           join Zamowienie in _con.Zamowienia on Zamowienie_WyrobCukierniczy.IdZamowienia equals Zamowienie.IdZamowienia
                           join WyrobCukierniczy in _con.WyrobyCukiernicze on Zamowienie_WyrobCukierniczy.IdWyrobu equals WyrobCukierniczy.IdWyrobu
                           select new OrderRespon()
                           {
                               IdWyrobu = Zamowienie.IdZamowienia,
                               CenaZaSzt = WyrobCukierniczy.CenaZaSzt,
                               DataPrzyjecia = Zamowienie.DataPrzyjecia,
                               Uwagi = Zamowienie.Uwagi,
                               Typ = WyrobCukierniczy.Typ
                           };
                var orderList = find.ToList();
                return orderList;

            }

            var client = from Zamowienie_WyrobCukierniczy in _con.Zamowienia_WyrobCukiernicze
                       join Zamowienie in _con.Zamowienia on Zamowienie_WyrobCukierniczy.IdZamowienia equals Zamowienie.IdZamowienia
                       join WyrobCukierniczy in _con.WyrobyCukiernicze on Zamowienie_WyrobCukierniczy.IdWyrobu equals WyrobCukierniczy.IdWyrobu
                       where Zamowienie.IdKlient== klient.IdKlient
                         select new OrderRespon()
                         {
                             IdWyrobu = Zamowienie.IdZamowienia,
                             CenaZaSzt = WyrobCukierniczy.CenaZaSzt,
                             DataPrzyjecia = Zamowienie.DataPrzyjecia,
                             Uwagi = Zamowienie.Uwagi,
                             Typ = WyrobCukierniczy.Typ
                         };
            var lista = client.ToList();
            return lista;


           
                        
        }
    }
}
