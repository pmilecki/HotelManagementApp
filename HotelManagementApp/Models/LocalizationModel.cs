using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApp.Models
{
    public class LocalizationModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1,10)]
        [DisplayName("Piętro")]
        public int Floor { get; set; }

        [Required]
        [DisplayName("Szkrzydło")]
        public string Wing { get; set; }
    }
}
