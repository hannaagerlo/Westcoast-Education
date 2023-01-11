using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Authorization
{
    public class UserAuthViewModel
    {
        public string? UserName { get; set; }
        public DateTime Expires { get; set; }
        public string? Token { get; set; }
         public bool IsLoggedIn { get; set; } 
    }
}