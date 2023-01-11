using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels
{
    public class StudentWithCourseViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? EmailAddress { get; set; }
         public string? PhoneNumber { get; set; }
         public string? Adress { get; set; }

         public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();

    }
}