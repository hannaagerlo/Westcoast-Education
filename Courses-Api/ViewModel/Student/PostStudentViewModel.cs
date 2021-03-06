using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Student
{
    public class PostStudentViewModel
    {
         public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? EmailAdress { get; set; }

        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? Municipality { get; set; }
        public DateTime Expires { get; set; }
         public string? Token { get; set; }
    }
}