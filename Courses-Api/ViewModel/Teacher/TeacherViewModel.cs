using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Competence;

namespace Courses_Api.ViewModel.Teacher
{
    public class TeacherViewModel
    {
         public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Competence { get; set; }
        // public List<CompetenceViewModel> Competences { get; set; } = new List<CompetenceViewModel>();

    }
}