using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Teacher
{
    public class TeacherViewModel
    {
         public int TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public string? Expertise { get; set; }
    }
}