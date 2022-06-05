using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.ViewModel.Admin
{
    public class AdminViewModel
    {
        public string? EmailAdress { get; set; }
        public DateTime Expires { get; set; }
        public string? Token { get; set; }

    }
}