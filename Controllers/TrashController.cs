using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class TrashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
