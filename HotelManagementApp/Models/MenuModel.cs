using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HotelManagementApp.Models
{
    public class MenuModel
    {
        [JsonPropertyName("day")]
        [DisplayName("Dzień tygodnia")]
        public string Day { get; set; }
        [DisplayName("Zupa")]
        [JsonPropertyName("soup")]
        public string Soup { get; set; }
        [DisplayName("Danie główne")]
        [JsonPropertyName("mainDish")]
        public string MainDish { get; set; }
    }
}
