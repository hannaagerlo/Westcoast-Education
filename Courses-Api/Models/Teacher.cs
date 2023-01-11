using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Courses_Api.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [PersonalData]
        [Required]
        public string? Firstname { get; set; }

        [PersonalData]
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
         public string? Street { get; set; }
        [Required]
        public string? StreetNumber { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? City { get; set; }
        public int CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public Competence? CompetenceName { get; set; }

         public ICollection<Course> Courses { get; set; } = new List<Course>();

        //public ICollection<TeacherCourse> TeacherCourses {get; set;} = new List<TeacherCourse>();

    }
}