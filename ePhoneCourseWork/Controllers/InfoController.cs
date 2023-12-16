using Microsoft.AspNetCore.Mvc;

namespace ePhoneCourseWork.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }
    }
}
