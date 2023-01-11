using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Courses_Api.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Required]
        public string? FirstName { get; set; }
        [PersonalData]
        [Required]
        public string? LastName { get; set; }
         public string? Street { get; set; }
        [Required]
        public string? StreetNumber { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? City { get; set; }
        public bool IsLoggedIn { get; set; } 

       //public List<UserRole>? UserRole { get; set; }

       public ICollection<StudentCourse> StudentCourses {get; set;} = new List<StudentCourse>();
    //    public ICollection<TeacherCourse> TeacherCourses {get; set;} = new List<TeacherCourse>();
    //    public ICollection<TeacherCompetence> TeacherCompetences {get; set;} = new List<TeacherCompetence>();

    }
}