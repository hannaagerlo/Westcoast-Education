using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels
{
    public class CreateCourseViewModel
    {
        public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
        public string? Lenght { get; set; }
        //public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
         public int TeacherId { get; set; }
       
    }
}