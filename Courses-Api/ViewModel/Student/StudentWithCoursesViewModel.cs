using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Courses;

namespace Courses_Api.ViewModel.Student
{
    public class StudentWithCoursesViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }

        public List<CourseViewModel> Courses {get; set;} = new List<CourseViewModel>();

    }
}