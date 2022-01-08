using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApp.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
