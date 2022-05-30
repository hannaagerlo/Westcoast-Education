using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Interface;
using Courses_Api.ViewModel.Student;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

         [HttpGet]
        public async Task<ActionResult<List<StudentViewModel>>> ListCourses()
        {
             return Ok(await _studentRepo.ListAllCoursesAsync());

        
        }

        // GET Category
        [HttpGet("/bycategory{category}")]
        public async Task<ActionResult<StudentViewModel>> GetCourseByCategory(string category)
        {
            var response = await _courseRepo.GetCourseAsync(category);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta några kurser med kategorin: {category}");

            return Ok(response);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult> AddCourse(PostCoursesViewModel course)
        {
            // måste lägga in felhantering, ska inte gå att spara en kurs med samma kursnummer.
                await _courseRepo.AddCourseAsync(course);
                if (await _courseRepo.SaveAllAsync())
                {
                    return StatusCode(201);
                }
                return StatusCode(500, "Det gick inte att spara kursen");


                

            
            // var courseToAdd = new Course
            // {
            //     CourseNumber = course.CourseNumber,
            //     Title = course.Title,
            //     Lenght = course.Lenght,
            //     Category = course.Category,
            //     Description = course.Description,
            //     Details = course.Details
            // };
            // await _context.Courses.AddAsync(courseToAdd);
            // await _context.SaveChangesAsync();
            // return StatusCode(201, course);
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourseAsync(int id, PostCoursesViewModel course)
        {
            await _courseRepo.UpdateCourseAsync(id, course);
            if(await _courseRepo.SaveAllAsync())
            {
                return StatusCode(204, "Kursen är uppdaterad");
            }
            return StatusCode(500, "Ett fel inträffade när kursen skulle uppdateras");


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseAsync(int id)
        {
            await _courseRepo.DeleteCourseAsync(id);
            if(await _courseRepo.SaveAllAsync())
            {
                return StatusCode(204, "Kursen är bort tagen från systemet");
            }
            return StatusCode(500, "Ett fel inträffade när kursen skulle tas bort");
        }
        
    }
}