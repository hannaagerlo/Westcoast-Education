using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.Models
{
    public class TeacherCompetence
    {
        [ForeignKey("TeacherId")]
        public User? Teacher { get; set; }
        public string? TeacherId { get; set; }
        public Competence? Competence { get; set; }
        public int CompetenceId { get; set; }
    }
}