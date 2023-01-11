using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Courses_Api.ViewModel.Courses;

namespace Courses_Api.ViewModel.StudentCourse
{
    public class StudentRegisteredCoursesViewModel
    {
        public string? StudentId { get; set; }
        public string? CourseId { get; set; }
        public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
    
    }
}