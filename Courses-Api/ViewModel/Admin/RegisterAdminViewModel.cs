using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Admin
{
    public class RegisterAdminViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Felagtig e-post adress")]
        public string? EmailAdress { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool IsAdmin { get; set; } = true;
    }
}