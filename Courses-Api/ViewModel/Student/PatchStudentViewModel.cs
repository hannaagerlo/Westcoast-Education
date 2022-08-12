using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;

namespace Courses_Api.ViewModel.Student
{
    public class PatchStudentViewModel
    {
        public int StudentId { get; set; }
        // public string? StudentName { get; set; }
        // public string? EmailAdress { get; set; }
        // public string? PhoneNumber { get; set; }
        // public string? Adress { get; set; }
        public int CourseId { get; set; }
    
    }
}