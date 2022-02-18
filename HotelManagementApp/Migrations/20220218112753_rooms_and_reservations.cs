using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementApp.Migrations
{
    public partial class rooms_and_reservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokalizacja = table.Column<int>(type: "int", nullable: false),
                    DostepnyDoUzytku = table.Column<bool>(type: "bit", nullable: false),
                    IloscLozekPojedynczych = table.Column<int>(type: "int", nullable: false),
                    IloscLozekPodwojnych = table.Column<int>(type: "int", nullable: false),
                    IloscLazienek = table.Column<int>(type: "int", nullable: false),
                    KosztZaNoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumerPokoju = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPokoju = table.Column<int>(type: "int", nullable: false),
                    PoczatekRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoniecRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRezerwujacego = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");
        }
    }
}
