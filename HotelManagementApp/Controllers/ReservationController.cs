using HotelManagementApp.Models;
using HotelManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagementApp.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index(string roomId)
        {
            var roomReservation = new ReservationModel();
            roomReservation.RoomNumber = int.Parse(roomId);
            return View(roomReservation);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceReservation(ReservationModel reservation)
        {
            await _reservationService.Add(reservation);
            return View();
        }
    }
}
