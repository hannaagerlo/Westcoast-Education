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
        public async Task<ActionResult<List<StudentViewModel>>> ListStudent()
        {
             return Ok(await _studentRepo.ListAllStudentsAsync());        
        }

        // Sök/lista student efter Id nummer. 
        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudentById(int id)
        {
            var response = await _studentRepo.GetStudentAsync(id);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta några kurser med kategorin: {id}");

            return Ok(response);
        }      
        
    
        //POST
        [HttpPost]
        public async Task<ActionResult> AddStudent(PostStudentViewModel student)
        {
            // måste lägga in felhantering, ska inte gå att spara en kurs med samma kursnummer.
                await _studentRepo.AddStudentAsync(student);
                if (await _studentRepo.SaveAllAsync())
                {
                    return StatusCode(201);
                }
                return StatusCode(500, "Det gick inte att spara den nya användaren");


                

            
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
        public async Task<ActionResult> UpdateCourseAsync(int id, PostStudentViewModel course)
        {
            await _studentRepo.UpdateStudentAsync(id, course);
            if(await _studentRepo.SaveAllAsync())
            {
                return StatusCode(204, "Användaren är uppdaterad");
            }
            return StatusCode(500, "Ett fel inträffade när användaren skulle uppdateras");


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentAsync(int id)
        {
            await _studentRepo.DeleteStudentAsync(id);
            if(await _studentRepo.SaveAllAsync())
            {
                return StatusCode(204, "Användaren är bort tagen från systemet");
            }
            return StatusCode(500, "Ett fel inträffade när användaren skulle tas bort");
        }
        
    }
}