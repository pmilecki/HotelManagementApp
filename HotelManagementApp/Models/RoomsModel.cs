using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HotelManagementApp.Database;
using HotelManagementApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagementApp.Models
{
    public class RoomsModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Numer Pokoju")]
        public int RoomNumber { get; set; }

        [Required]
        [DisplayName("Lokalizacja")]
        public int Localization { get; set; }

        [Required]
        [DisplayName("Czy do użytku?")]
        public bool IsUsable { get; set; }

        [Required]
        [DisplayName("Liczba pojedynczych łóżek")]
        public int NoOfSingleBeds { get; set; }

        [Required]
        [DisplayName("Liczba podwójnych łóżek")]
        public int NoOfDualBeds { get; set; }

        [Required]
        [DisplayName("Liczba łazienek")]
        public int NoOfBathrooms { get; set; }

        [Required]
        [DisplayName("Koszt za noc")]
        public decimal CostPerNight { get; set; }

        public string FullLocalization { get; set; }

        public SelectList Localizations { get; set; }
    }
}
