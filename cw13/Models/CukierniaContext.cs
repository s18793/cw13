using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw13.Models
{
    public class CukierniaContext : DbContext
    {


        public DbSet<Klient> Klients { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }

        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }

        public DbSet<Zamowienie> Zamowienia { get; set; }

        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobCukiernicze { get; set; }
        public CukierniaContext() { }

        public CukierniaContext(DbContextOptions options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //klient
            modelBuilder.Entity<Klient>().HasKey(s => s.IdKlient);
            modelBuilder.Entity<Klient>().Property(s => s.Imie).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Klient>().Property(s => s.Nazwisko).HasMaxLength(40).IsRequired();

            var klientciLista = new List<Klient>();
            
            klientciLista.Add(new Models.Klient { IdKlient = 1, Imie = "Anna", Nazwisko = "Mazur" });
            klientciLista.Add(new Models.Klient { IdKlient = 2, Imie = "Paweł", Nazwisko = "Mazur" });
            klientciLista.Add(new Models.Klient { IdKlient = 3, Imie = "Piotr", Nazwisko = "Stankiewicz" });

            modelBuilder.Entity<Klient>().HasData(klientciLista);

            //pracownik
            modelBuilder.Entity<Pracownik>().HasKey(s => s.IdPracownik);
            modelBuilder.Entity<Pracownik>().Property(s => s.Imie).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Pracownik>().Property(s => s.Nazwisko).HasMaxLength(40).IsRequired();

            var pracownicyLista = new List<Pracownik>();

            pracownicyLista.Add(new Models.Pracownik { IdPracownik = 1, Imie = "Jan", Nazwisko = "Panek" });
            pracownicyLista.Add(new Models.Pracownik { IdPracownik = 2, Imie = "Paweł", Nazwisko = "Topiel" });
            pracownicyLista.Add(new Models.Pracownik { IdPracownik = 3, Imie = "Artur", Nazwisko = "Kazol" });

            modelBuilder.Entity<Pracownik>().HasData(pracownicyLista);


            ///wyrobCukeirniczy
            modelBuilder.Entity<WyrobCukierniczy>().HasKey(s => s.IdWyrobu);
            modelBuilder.Entity<WyrobCukierniczy>().Property(s => s.Nazwa).HasMaxLength(70).IsRequired();
            modelBuilder.Entity<WyrobCukierniczy>().Property(s => s.CenaZaSzt).IsRequired();
            modelBuilder.Entity<WyrobCukierniczy>().Property(s => s.Typ).HasMaxLength(50).IsRequired();

            var wyrobyCukierLista = new List<WyrobCukierniczy>();

            wyrobyCukierLista.Add(new Models.WyrobCukierniczy { IdWyrobu = 1, Nazwa = "Tort", CenaZaSzt = 20.5, Typ="słodkie" });
            wyrobyCukierLista.Add(new Models.WyrobCukierniczy { IdWyrobu = 2, Nazwa = "Sernik", CenaZaSzt = 10, Typ="Eko słodkie" });
            wyrobyCukierLista.Add(new Models.WyrobCukierniczy { IdWyrobu = 3, Nazwa = "Paczek", CenaZaSzt = 4.5 , Typ="słodkie"});

            modelBuilder.Entity<WyrobCukierniczy>().HasData(wyrobyCukierLista);


            ///zamowienia 
            ///
            modelBuilder.Entity<Zamowienie>().HasKey(s => s.IdZamowienia);
            modelBuilder.Entity<Zamowienie>().Property(s => s.DataPrzyjecia).IsRequired();
            
            modelBuilder.Entity<Zamowienie>().Property(s => s.Uwagi).HasMaxLength(100).IsRequired();

            var zamowieniaLista = new List<Zamowienie>();

            zamowieniaLista.Add(new Models.Zamowienie { IdZamowienia = 1, DataPrzyjecia = System.DateTime.Now, DataRealizacji = System.DateTime.Now, Uwagi = "Zapakowac na prezent", IdKlient = 1, IdPracownik = 1 });
            zamowieniaLista.Add(new Models.Zamowienie { IdZamowienia = 2, DataPrzyjecia = System.DateTime.Now, DataRealizacji = System.DateTime.Now, Uwagi = "Bez orzechów", IdKlient = 2, IdPracownik = 3 });
            zamowieniaLista.Add(new Models.Zamowienie { IdZamowienia = 3, DataPrzyjecia = System.DateTime.Now, DataRealizacji = System.DateTime.Now, Uwagi = "Zapakowac na prezent", IdKlient = 3, IdPracownik = 1 });

            modelBuilder.Entity<Zamowienie>().HasData(zamowieniaLista);

            //zamowienie wyrobu cukierniczego

             modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                        .HasKey(e =>new { e.IdWyrobu, e.IdZamowienia });
            
           //////
           
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                        .Property(e => e.Ilosc)
                        .IsRequired();
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                        .Property(e => e.Uwagi)
                        .HasMaxLength(300);
            var zamowienieWyroblista = new List<Zamowienie_WyrobCukierniczy>();
            zamowienieWyroblista.Add(new Models.Zamowienie_WyrobCukierniczy { IdWyrobu = 1, IdZamowienia = 1, Ilosc = 10, Uwagi = "null" });
            zamowienieWyroblista.Add(new Models.Zamowienie_WyrobCukierniczy { IdWyrobu = 2, IdZamowienia = 2, Ilosc = 1, Uwagi = "null" });
            zamowienieWyroblista.Add(new Models.Zamowienie_WyrobCukierniczy { IdWyrobu = 3, IdZamowienia = 3, Ilosc = 30, Uwagi = "null" });
            zamowienieWyroblista.Add(new Models.Zamowienie_WyrobCukierniczy { IdWyrobu = 1, IdZamowienia = 2, Ilosc = 1, Uwagi = "null" });
            zamowienieWyroblista.Add(new Models.Zamowienie_WyrobCukierniczy { IdWyrobu = 2, IdZamowienia = 1, Ilosc = 3, Uwagi = "null" });
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasData(zamowienieWyroblista); 
        }
    } 
}
