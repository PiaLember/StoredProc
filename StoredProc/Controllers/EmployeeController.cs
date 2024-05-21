using Microsoft.AspNetCore.Mvc;

namespace TTHKStoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}