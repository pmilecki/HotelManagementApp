using CanteenCatering.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CanteenCatering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<WeeklyMenuModel> Send()
        {

            List<WeeklyMenuModel> weeklyMenuList = new List<WeeklyMenuModel>();

            weeklyMenuList.Add(new WeeklyMenuModel("Poniedziałek", "Kalafiarowa", "Placki ziemniaczane"));
            weeklyMenuList.Add(new WeeklyMenuModel("Wtorek", "Krem z cebuli", "Pierogi z mięsem"));
            weeklyMenuList.Add(new WeeklyMenuModel("Środa", "Kalafiarowa", "Placki ziemniaczane"));
            weeklyMenuList.Add(new WeeklyMenuModel("Czwartek", "Kalafiarowa", "Placki ziemniaczane"));
            weeklyMenuList.Add(new WeeklyMenuModel("Piątek", "Kalafiarowa", "Placki ziemniaczane"));

            var result = weeklyMenuList as IEnumerable<WeeklyMenuModel>;

            return result;
        }
    }
}
