using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.Models
{
    public class TeacherCourse
    {
        [ForeignKey("TeacherId")]
        public string? TeacherId { get; set; }
        public User? Teacher { get; set; }

        public int CourseId { get; set; }
        public Course? Course{ get; set; }
    }
}