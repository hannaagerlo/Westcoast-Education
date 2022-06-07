using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Courses_Api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? Municipality { get; set; }


        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}