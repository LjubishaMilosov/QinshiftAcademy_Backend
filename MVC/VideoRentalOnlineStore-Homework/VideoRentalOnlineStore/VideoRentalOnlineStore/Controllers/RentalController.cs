using Microsoft.AspNetCore.Mvc;

namespace VideoRentalOnlineStore.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
