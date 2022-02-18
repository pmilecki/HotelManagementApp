using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementApp.Migrations
{
    public partial class rooms_and_reservations_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Localization = table.Column<int>(type: "int", nullable: false),
                    IsUsable = table.Column<bool>(type: "bit", nullable: false),
                    NoOfSingleBeds = table.Column<int>(type: "int", nullable: false),
                    NoOfDualBeds = table.Column<int>(type: "int", nullable: false),
                    NoOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    CostPerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DostepnyDoUzytku = table.Column<bool>(type: "bit", nullable: false),
                    IloscLazienek = table.Column<int>(type: "int", nullable: false),
                    IloscLozekPodwojnych = table.Column<int>(type: "int", nullable: false),
                    IloscLozekPojedynczych = table.Column<int>(type: "int", nullable: false),
                    KosztZaNoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lokalizacja = table.Column<int>(type: "int", nullable: false),
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
                    IdRezerwujacego = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KoniecRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoczatekRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                });
        }
    }
}
