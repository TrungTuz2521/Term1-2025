using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
