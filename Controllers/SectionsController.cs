using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class SectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
