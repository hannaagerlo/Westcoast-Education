using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInterface.ViewModels.Student
{
    public class StudentViewModel
    {
       
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? EmailAdress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
    
    }
}
