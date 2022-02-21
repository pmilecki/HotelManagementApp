using HotelManagementApp.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApp.Models
{
    public class ReservationModel
    {
        public int RoomNumber { get; set; }

        [Required]
        public DateTime ReservationStart { get; set; }

        [Required]
        public DateTime ReservationEnd { get; set; }
        
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Podana nazwa jest za krótka")]
        [Required]
        public string CustomerName { get; set; }

        [RegularExpression(@"^[0-9]+$"), StringLength(9), MinLength(9)]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
