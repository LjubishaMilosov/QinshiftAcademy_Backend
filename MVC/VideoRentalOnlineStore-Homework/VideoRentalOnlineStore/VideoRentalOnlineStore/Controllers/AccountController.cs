using Microsoft.AspNetCore.Mvc;

namespace VideoRentalOnlineStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
