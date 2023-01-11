using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Courses_Api.Models
{
    public class Competence
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        // public ICollection<TeacherCompetence> TeacherComps { get; set; } = new List<TeacherCompetence>();

    }
}