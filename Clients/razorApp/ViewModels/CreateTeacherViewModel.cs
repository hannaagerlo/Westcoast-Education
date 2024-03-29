using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels
{
    public class CreateTeacherViewModel
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Competence { get; set; }
    }
}