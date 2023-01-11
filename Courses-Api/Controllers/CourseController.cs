using AutoMapper;
using Courses_Api.Data;
using Courses_Api.Helpers.UserHelper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesRepository _courseRepo;
        private readonly IUserHelper _userHelper;

        public CourseController(ICoursesRepository courseRepo, IUserHelper userHelper)
        {
            _courseRepo = courseRepo;
            _userHelper = userHelper;
        }

        // GET
        [HttpGet("list")]
        public async Task<ActionResult<List<CourseViewModel>>> ListCourses()
        {
             return Ok(await _courseRepo.ListAllCoursesAsync());

            // var response = await _courseRepo.ListAllCoursesAsync();
            // var courseList = new List<CourseViewModel>();

            // foreach(var course in response)
            // {
            //     courseList.Add(
            //         new CourseViewModel{
            //             CourseId = course.Id,
            //             CourseNumber = course.CourseNumber,
            //             Title = course.Title,
            //             Lenght = course.Lenght,
            //             Category = course.Category,
            //             Description = course.Description,
            //             Details = course.Details
            //         }
            //     );
            // }
            // return Ok(courseList);

        
        }
          [HttpGet("listWithTeachers")]
        public async Task<ActionResult<List<CourseViewModel>>> ListCoursesWithTeacher()
        {
             return Ok(await _courseRepo.ListAllCoursesWithTeacherAsync());

            // var response = await _courseRepo.ListAllCoursesAsync();
            // var courseList = new List<CourseViewModel>();

            // foreach(var course in response)
            // {
            //     courseList.Add(
            //         new CourseViewModel{
            //             CourseId = course.Id,
            //             CourseNumber = course.CourseNumber,
            //             Title = course.Title,
            //             Lenght = course.Lenght,
            //             Category = course.Category,
            //             Description = course.Description,
            //             Details = course.Details
            //         }
            //     );
            // }
            // return Ok(courseList);

        
        }
        [HttpGet("{id}")]    
        public async Task<ActionResult<CourseViewModel>> GetCourseById(int id)
        {
            
            var response = await _courseRepo.GetCourseByIdAsync(id);

            
            if (response is null)
                
                return NotFound($"Vi kunde inte hitta någon kurs med id: {id}");

            
            return Ok(response);
        }

        // GET Category
        // [HttpGet("bycategory/{category}")]
        // public async Task<ActionResult<List<CourseViewModel>>> GetCourseByCategory(string category)
        // {
        //     var response = await _courseRepo.GetCourseAsync(category);
            
        //     if(response is null)
        //     return NotFound($"Det gick inte att hitta några kurser med kategorin: {category}");

        //     return Ok(response);
        // }
        //POST
        [HttpPost]
        public async Task<ActionResult> AddCourse(PostCourseViewModel course)
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
        public async Task<ActionResult> UpdateCourseAsync(int id, PutCourseViewModel course)
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
        
        
       [HttpPost("signup/{courseId}")]
        public async Task<ActionResult> SignUpForCourses(int courseId)
        {
            var loggedInStudent = _userHelper.LoggedInStudent()?.Email;

            if (loggedInStudent is null)
                throw new Exception("Ingen användare är inloggad");

            await _courseRepo.SignUpForCourses(loggedInStudent, courseId);

            return Ok();
        }
    }
}