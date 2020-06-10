using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw13.Migrations
{
    public partial class AddedAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klients",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 40, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klients", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 40, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyrobu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 70, nullable: false),
                    CenaZaSzt = table.Column<double>(nullable: false),
                    Typ = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobyCukiernicze", x => x.IdWyrobu);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: true),
                    Uwagi = table.Column<string>(maxLength: 100, nullable: false),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia_WyrobCukiernicze",
                columns: table => new
                {
                    IdWyrobu = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia_WyrobCukiernicze", x => new { x.IdWyrobu, x.IdZamowienia });
                });

            migrationBuilder.InsertData(
                table: "Klients",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Anna", "Mazur" },
                    { 2, "Paweł", "Mazur" },
                    { 3, "Piotr", "Stankiewicz" }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Panek" },
                    { 2, "Paweł", "Topiel" },
                    { 3, "Artur", "Kazol" }
                });

            migrationBuilder.InsertData(
                table: "WyrobyCukiernicze",
                columns: new[] { "IdWyrobu", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 2, 10.0, "Sernik", "Eko słodkie" },
                    { 3, 4.5, "Paczek", "słodkie" },
                    { 1, 20.5, "Tort", "słodkie" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 10, 17, 28, 45, 343, DateTimeKind.Local).AddTicks(7543), new DateTime(2020, 6, 10, 17, 28, 45, 349, DateTimeKind.Local).AddTicks(4164), 1, 1, "Zapakowac na prezent" },
                    { 2, new DateTime(2020, 6, 10, 17, 28, 45, 349, DateTimeKind.Local).AddTicks(7489), new DateTime(2020, 6, 10, 17, 28, 45, 349, DateTimeKind.Local).AddTicks(7521), 2, 3, "Bez orzechów" },
                    { 3, new DateTime(2020, 6, 10, 17, 28, 45, 349, DateTimeKind.Local).AddTicks(7561), new DateTime(2020, 6, 10, 17, 28, 45, 349, DateTimeKind.Local).AddTicks(7565), 3, 1, "Zapakowac na prezent" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia_WyrobCukiernicze",
                columns: new[] { "IdWyrobu", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[,]
                {
                    { 1, 2, 1, "null" },
                    { 1, 1, 10, "null" },
                    { 2, 2, 1, "null" },
                    { 3, 3, 30, "null" },
                    { 2, 1, 3, "null" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klients");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "WyrobyCukiernicze");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Zamowienia_WyrobCukiernicze");
        }
    }
}
