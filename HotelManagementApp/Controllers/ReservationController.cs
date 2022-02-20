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

        public async Task<IActionResult> Index(string roomId)
        {
            var roomReservation = new ReservationModel();
            roomReservation.RoomNumber = int.Parse(roomId);
            roomReservation.PhoneNumber = await _reservationService.GetUserPhone();
            return View(roomReservation);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceReservation(ReservationModel reservation)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", reservation);
            }
            else
            {
                await _reservationService.Add(reservation);
                return View();
            }
        }

        public async Task<IActionResult> ReservationList()
        {
            var reservation = await _reservationService.GetAll();
            return View(reservation);
        }
    }
}
