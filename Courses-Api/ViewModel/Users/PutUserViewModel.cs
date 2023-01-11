using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Users
{
    public class PutUserViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
         [Required]
        public string? LastName { get; set; }
         [Required]
        public string? Email { get; set; }
         [Required]
        public string? PhoneNumber { get; set; }
         [Required]
    
        public string? Street { get; set; }
         [Required]
        public string? StreetNumber { get; set; }
         [Required]
        public string? PostalCode { get; set; }
         [Required]
        public string? City { get; set; }
    }
}