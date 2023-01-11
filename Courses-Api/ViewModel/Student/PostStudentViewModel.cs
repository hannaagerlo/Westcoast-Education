using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Student
{
    public class PostStudentViewModel
    {

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
         public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public bool IsLoggedIn { get; set; } 

        // public DateTime Expires { get; set; }
        //  public string? Token { get; set; }
    }
}