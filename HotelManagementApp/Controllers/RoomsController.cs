using HotelManagementApp.Database;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using HotelManagementApp.Services;

namespace HotelManagementApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        public IActionResult Index(string id)
        {
            var room = _roomsService.GetRoom(id);
            return View(room);
        }
    }
}
