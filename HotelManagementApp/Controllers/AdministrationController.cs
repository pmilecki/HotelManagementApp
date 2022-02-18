﻿using HotelManagementApp.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApp.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdministrationController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AdministrationController (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
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
    }
}