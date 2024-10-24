using Microsoft.AspNetCore.Mvc;

namespace Restaurant_manager_x_backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Console.WriteLine("The app is working.");
            return View();
        }
    }
}