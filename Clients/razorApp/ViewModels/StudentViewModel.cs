using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razorApp.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

    }
}