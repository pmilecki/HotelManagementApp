using HotelManagementApp.Database;
using HotelManagementApp.Models;
using HotelManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManagementApp.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdministrationController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IReservationService _reservationService;
        private readonly IRoomsService _roomsService;

        public AdministrationController (AppDbContext dbContext, IReservationService reservationService, IRoomsService roomsService)
        {
            _dbContext = dbContext;
            _reservationService = reservationService;
            _roomsService = roomsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult AddLocalization()
        {
            return View();
        }

        public IActionResult AddRoom()
        {
            RoomsModel model = new RoomsModel();

            model.Localizations = _roomsService.GetAllLocalizations();
            return View(model);
        }

        public async Task<IActionResult> AddLocalizationToDB(LocalizationModel localization)
        {
            if (!ModelState.IsValid)
            {
                return View("AddLocalization", localization);
            }
            else
            {
                await _roomsService.AddLocalization(localization);
                return View("AdminPage");
            }
        }

        public async Task<IActionResult> AddRoomToDB(RoomsModel room)
        {
            if (!ModelState.IsValid)
            {
                return View("AddRoom", room);
            }
            else
            {
                await _roomsService.Add(room);
                return View("AdminPage");
            }
        }

        public async Task<IActionResult> UsersList()
        {
            var users = await _dbContext.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> ReservationList()
        {
            var reservations = await _dbContext.Reservations.ToListAsync();
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> CancellingReservation(string cancelationData)
        {
            await _reservationService.RemoveReservation(cancelationData);
            return Ok();
        }
    }
}
