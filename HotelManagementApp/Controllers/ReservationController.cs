using HotelManagementApp.Models;
using HotelManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
                if (!_reservationService.IsRoomAvaliableForReservation(reservation))
                {
                    ModelState.AddModelError(nameof(reservation.ReservationEnd), "Pokój jest zarezerwowany w tym terminie");
                    return View("Index", reservation);
                }

                if (!_reservationService.IsEndDateAfterStartDate(reservation))
                {
                    ModelState.AddModelError(nameof(reservation.ReservationEnd), "Data końcowa musi być po: " + reservation.ReservationStart.ToShortDateString());
                    return View("Index", reservation);
                }

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
