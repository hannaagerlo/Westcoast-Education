using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Authorization
{
    public class LoginResponseViewModel 
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}