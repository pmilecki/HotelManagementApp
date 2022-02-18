using System.ComponentModel;
using System.Linq;
using HotelManagementApp.Database;
using HotelManagementApp.Entities;

namespace HotelManagementApp.Models
{
    public class RoomsModel
    {
        public int Id { get; set; }

        [DisplayName("Numer Pokoju")]
        public int RoomNumber { get; set; }

        [DisplayName("Lokalizacja")]
        public int Localization { get; set; }

        [DisplayName("Czy do użytku?")]
        public bool IsUsable { get; set; }

        [DisplayName("Liczba pojedynczych łóżek")]
        public int NoOfSingleBeds { get; set; }

        [DisplayName("Liczba podwójnych łóżek")]
        public int NoOfDualBeds { get; set; }

        [DisplayName("Liczba łazienek")]
        public int NoOfBathrooms { get; set; }

        [DisplayName("Koszt za noc")]
        public decimal CostPerNight { get; set; }

        public string FullLocalization { get; set; }
    }
}
