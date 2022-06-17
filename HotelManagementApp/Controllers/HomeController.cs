using HotelManagementApp.Database;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CanteenMenu()
        {
            using var client = new HttpClient();

            var url = "http://app2/api/canteenmenu";
            var result = await client.GetStringAsync(url);

            var menuList = JsonSerializer.Deserialize<List<MenuModel>>(result.ToString());

            return View(menuList);
        }

        public async Task<IActionResult> Rooms()
        {
            var rooms = await _dbcontext.Rooms.ToListAsync();
            return View(rooms);
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}