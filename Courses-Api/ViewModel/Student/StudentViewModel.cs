using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Student
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public DateTime Expires { get; set; }
         public string? Token { get; set; }
    
    }
}