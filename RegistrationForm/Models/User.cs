using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Place { get; set; }
    }
}