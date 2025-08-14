using MySql.Data.MySqlClient;
using RegistrationForm.Models;
using System;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class RegistrationController : Controller
    {
        private string connectionString = "server=localhost;user id=root;password=root;database=registration_db";

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO users (first_name, last_name, dob, place) VALUES (@first, @last, @dob, @place)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@first", user.First_Name);
                    cmd.Parameters.AddWithValue("@last", user.Last_Name);
                    cmd.Parameters.AddWithValue("@dob", user.DOB);
                    cmd.Parameters.AddWithValue("@place", user.Place);
                    cmd.ExecuteNonQuery();

                    ViewBag.Message = "Registration successful!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message;
                }
            }

            return View();
        }
    }
}
