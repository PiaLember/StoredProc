using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StoredProc.Data;
using StoredProc.Models;

namespace TTHKStoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config;

        public EmployeeController
            (
                StoredProcDbContext context,
                IConfiguration config
            )

            {
                _context = context;
                _config = config;
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

        [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> models = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    models.Add(details);
                }
                return View(models);
            }
        }
        [HttpPost]
        public IActionResult DynamicSQL(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using(SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "dbo.spSearchEmployees";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (firstName != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@FirstName", firstName);
                    command.Parameters.Add(parm_fn);
                }
                if (lastName != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@LastName", lastName);
                    command.Parameters.Add(parm_fn);
                }
                if (gender != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@Gender", gender);
                    command.Parameters.Add(parm_fn);
                }
                if (salary != 0)
                {
                    SqlParameter parm_fn = new SqlParameter("@Salary", salary);
                    command.Parameters.Add(parm_fn);
                }
                con.Open();
                SqlDataReader sdr = command.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }
            [HttpGet]
            public IActionResult DynamicSQLInStoredProcedure()
            {
                string connectionStr = _config.GetConnectionString("DefaultConnection");
               using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployeesGoodDynamicSQL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> models = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    models.Add(details);
                }
                return View(models);
            } 
         }
         [HttpPost]
        public IActionResult DynamicSQLInStoredProcedure(string firstName, string lastName, string gender, int salary)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");
            using(SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "dbo.spSearchEmployeesGoodDynamicSQL";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (firstName != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@FirstName", firstName);
                    command.Parameters.Add(parm_fn);
                }
                if (lastName != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@LastName", lastName);
                    command.Parameters.Add(parm_fn);
                }
                if (gender != null)
                {
                    SqlParameter parm_fn = new SqlParameter("@Gender", gender);
                    command.Parameters.Add(parm_fn);
                }
                if (salary != 0)
                {
                    SqlParameter parm_fn = new SqlParameter("@Salary", salary);
                    command.Parameters.Add(parm_fn);
                }
                con.Open();
                SqlDataReader sdr = command.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while (sdr.Read())
                {
                    var details = new Employee();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Salary = Convert.ToInt32(sdr["Salary"]);
                    model.Add(details);
                }
                return View(model);
            }
        }
    }
}