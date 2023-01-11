using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.StudentCourse
{
    public class PostStudentCourseViewModel
    {
        public string? StudentId { get; set; }
        public int CourseId { get; set; }   
        public bool HasRegistered { get; set; }
    }
}