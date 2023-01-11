using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Description { get; set; }
        public string? Details { get; set; }
        //public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = new Category();
        public int TeacherId { get; set; }
         [ForeignKey("TeacherId")]
        public Teacher? Teachers { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; } = new List<StudentCourse>();
         public ICollection<Student> Students { get; set; } = new List<Student>();
        //public ICollection<TeacherCourse> TeacherCourse { get; set; } = new List<TeacherCourse>();

        

    }
}