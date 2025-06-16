using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Controllers.Models;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        public string index()
        {
            return "Hello class, we are returning result via HTTP";
        }
    }
}