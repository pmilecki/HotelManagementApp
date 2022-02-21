using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApp.Entities
{
    public class ReservationsEntity
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Numer pokoju")]
        public int RoomId { get; set; }

        [DisplayName("Początek rezerwacji")]
        [DataType(DataType.Date)]
        public DateTime ReservationStart { get; set; }

        [DisplayName("Koniec rezerwacji")]
        [DataType(DataType.Date)]
        public DateTime ReservationEnd { get; set; }

        [DisplayName("ID klienta")]
        public string CustomerId { get; set; }

        [DisplayName("Nazwa klienta")]
        public string CustomerName { get; set; }

        [DisplayName("Numer Telefonu")]
        public string PhoneNumber { get; set; }
    }
}
