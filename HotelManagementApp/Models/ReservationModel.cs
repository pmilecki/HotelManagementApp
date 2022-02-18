using HotelManagementApp.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApp.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationEnd { get; set; }
        public IdentityUser CustomerId { get; set; }
        
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
