using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
        private readonly CourseContext _context;
        private readonly ICoursesRepository _courseRepo;
      
        public CourseController(CourseContext context, ICoursesRepository courseRepo)
        {
            _courseRepo = courseRepo;
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<List<CourseViewModel>>> ListCourses()
        {
            var response = await _courseRepo.ListAllCoursesAsync();
            var courseList = new List<CourseViewModel>();

            foreach(var course in response)
            {
                courseList.Add(
                    new CourseViewModel{
                        CourseId = course.Id,
                        CourseNumber = course.CourseNumber,
                        Title = course.Title,
                        Lenght = course.Lenght,
                        Category = course.Category,
                        Description = course.Description,
                        Details = course.Details
                    }
                );
            }
            return Ok(courseList);
        }

        // GET Category
        [HttpGet("{category}")]
        public async Task<ActionResult<Course>> GetCourseByCategory(string category)
        {
            var response = await _context.Courses.FindAsync(category);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta några kurser med kategorin: {category}");

            return Ok(200);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(PostCoursesViewModel course)
        {
            
            var courseToAdd = new Course
            {
                CourseNumber = course.CourseNumber,
                Title = course.Title,
                Lenght = course.Lenght,
                Category = course.Category,
                Description = course.Description,
                Details = course.Details
            };
            await _context.Courses.AddAsync(courseToAdd);
            await _context.SaveChangesAsync();
            return StatusCode(201, course);
        
        }
        
        // PUT
        //DELETE
    }
}