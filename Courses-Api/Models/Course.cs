using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
        public string? Lenght { get; set; }
        public string? Category { get; set; }   
        public string? Description { get; set; }
        public string? Details { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public Teacher Teachers { get; set; } = new Teacher();

    }
}