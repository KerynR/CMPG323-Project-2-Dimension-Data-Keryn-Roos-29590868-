using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace testing.Controllers
{
    public class FirstController : Controller
    {
        private readonly IConfiguration configuration;

        public FirstController(IConfiguration config)
        {
            this.configuration = config; 
        }

        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnection");

            SqlConnection connection = new SqlConnection();

            connection.Open();

            SqlCommand command = new SqlCommand("Select * from AspNetUsers", connection);


            connection.Close();

            return View();
        }
    }
}
