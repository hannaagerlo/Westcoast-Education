using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel
{
    public class PostCoursesViewModel
    {
        [Required(ErrorMessage = "Kursnummer är obligatoriskt")]
         public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
        public string? Lenght { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
         public string? ImageUrl { get; set; }
    }
}