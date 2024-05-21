using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProc.Data;
using StoredProc.Models;

namespace TTHKStoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;

        public EmployeeController
            (
                StoredProcDbContext context
            )

            {
                _context = context;
            }
        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employees
                .FromSqlRaw<Employee>("spSearchEmployees")
                .ToList();

            return result;
        }
    }
}