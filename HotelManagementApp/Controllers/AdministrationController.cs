using HotelManagementApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManagementApp.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> UsersList()
        {
            var users = await _dbContext.Users.ToListAsync();
            return View(users);
        }
    }
}
