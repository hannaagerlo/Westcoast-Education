using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Student
{
    public class RegisterUserViewModel
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Felagtig e-post adress")]
        public string? EmailAdress { get; set; }
        [Required]

        public string? PhoneNumber { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? Municipality { get; set; }
        [Required]
        public string? Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}