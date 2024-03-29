using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Courses
{
    public class CourseViewModel
    {
        public int CourseId { get; set; } 
        public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
        public string? Lenght { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        //public string? ImageUrl { get; set; }
    }
}