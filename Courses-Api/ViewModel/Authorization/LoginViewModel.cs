using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Authorization
{
    public class LoginViewModel 
    {
        // [Required]
        // public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }


        [Required]
        public string? Password { get; set; }
         public bool IsLoggedIn { get; set; } = true;

        // public string? StudentId { get; set; }
        // public string? StudentName { get; set; }
    }
}