using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelCanteen.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CanteenMenuController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<string> RecieveMenu()
        {
            using var client = new HttpClient();

            var url = "http://app3/api/menu";
            var result = await client.GetStringAsync(url);

            return result;
        }
    }
}
