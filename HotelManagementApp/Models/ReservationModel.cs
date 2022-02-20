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
        
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Podana nazwa jest za krótka")]
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Numer telefonu musi składać się z 9 cyfr")]
        public string PhoneNumber { get; set; }
    }
}
