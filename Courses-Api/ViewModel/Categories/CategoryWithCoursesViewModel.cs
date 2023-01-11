using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Courses;

namespace Courses_Api.ViewModel.Categories
{
    public class CategoryWithCoursesViewModel
    {
         public int CategoryId { get; set; }
        public string? Category { get; set; }

        public List<CourseViewModel> Courses {get; set;} = new List<CourseViewModel>();


    }
}