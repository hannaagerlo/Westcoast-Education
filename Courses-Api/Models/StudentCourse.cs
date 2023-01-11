using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.Models
{
    public class StudentCourse
    {
        [ForeignKey("StudentId")]
        public string? StudentId { get; set; }
        public User? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course{ get; set; }

        public bool HasRegistered { get; set; } = false;
    }
}