using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Admin
{
    public class LoginAdminViewModel
    {
        [Required]
        public string? EmailAdress { get; set; }
        [Required]
        public string? Password { get; set; }

        
    }
}