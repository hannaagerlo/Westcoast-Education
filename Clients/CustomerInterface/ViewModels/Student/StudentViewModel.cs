using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInterface.ViewModels.Student
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "E-post är obligatoriskts")]
        [EmailAddress(ErrorMessage ="Felagtig e-post")]
        public string? EmailAdress { get; set; }

         [Required(ErrorMessage = "Lösenord är obligatoriskts")]
         public string? Password { get; set; }
    }
}