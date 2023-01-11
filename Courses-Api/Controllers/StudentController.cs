using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Helpers.UserHelper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Authorization;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.StudentCourse;
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUserHelper _userHelper;
        private readonly IMapper _mapper;
         private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
          private readonly SignInManager<User> _signManager;
        private readonly IConfiguration _config;

        public StudentController(IStudentRepository studentRepo, IUserHelper userHelper, IMapper mapper, 
        UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config,
         IUserRepository userRepo, SignInManager<User> signManager)
        {
            _studentRepo = studentRepo;
            _userHelper = userHelper;
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepo = userRepo;
            _signManager = signManager;

        }
           [HttpGet]
        public async Task<ActionResult<List<StudentViewModel>>> ListStudent()
        {
             return Ok(await _studentRepo.ListAllStudentsAsync());        
        }

        [HttpGet("getLoggedInUser")]
        public StudentViewModel? LoggedInStudent()
        {
            return _userHelper.LoggedInStudent();
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentViewModel>>> GetStudentById(int id)
        {
            var response = await _studentRepo.GetStudentAsync(id);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta några kurser med kategorin: {id}");

            return Ok(response);
        }   

         [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentAsync(int id, PostStudentViewModel student)
        {
            await _studentRepo.UpdateStudentAsync(id, student);
            if(await _studentRepo.SaveAllAsync())
            {
                return StatusCode(204, "Användaren är uppdaterad");
            }
            return StatusCode(500, "Ett fel inträffade när användaren skulle uppdateras");


        }
        
        //  private async Task<string> CreateJwtToken(User user)
        // {
        //   var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("apiKey"));
        //   var userClaims = (await _userManager.GetClaimsAsync(user)).ToList();

        //   var jwt = new JwtSecurityToken(
        //       claims: userClaims,
        //       notBefore: DateTime.Now,
        //       expires: DateTime.Now.AddDays(7),
        //       signingCredentials: new SigningCredentials(
        //           new SymmetricSecurityKey(key),
        //           SecurityAlgorithms.HmacSha512Signature
        //       )
        //   );
        //   return new JwtSecurityTokenHandler().WriteToken(jwt);
        // }   

       

        // [HttpGet("studentsWithCourses/{id}")]
        // public async Task<ActionResult> GetStudentWithCourses(int id)
        // {
        //     var response = await _studentRepo.GetStudentWithCourses(id);
            
        //     if(response is null)
        //     return NotFound($"Det gick inte att hitta några kurser: ");

        //     return Ok(response);
        // }    

        [HttpGet("studentsWithCourses/{id}")]
        public async Task<ActionResult<StudentWithCoursesViewModel>> GetStudentWithCourses(int id)
        {
            var response = await _studentRepo.GetStudentWithCourses(id);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta några kurser: ");

            return Ok(response);
        } 
        
    
        // [HttpPost]
        // public async Task<ActionResult> AddStudentAsync(PostUserViewModel student)
        // {
        //     var studentToAdd = _mapper.Map<User>(student);
        //     studentToAdd.UserName = studentToAdd.Email;
        //     await _studentRepo.AddStudentAsync(student);
        //     if (await _studentRepo.SaveAllAsync() && !string.IsNullOrEmpty(student.RoleName))
        //     {
        //         await _studentRepo.SetRoleAsync(studentToAdd, student.RoleName);
        //         return StatusCode(201, "Användaren är skapad");
        //     }
        //     return StatusCode(500, "Det gick inte att spara den nya användaren");

        // }

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


        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteStudentAsync(string id)
        // {
        //     // var userToDelete = await _userManager.FindByIdAsync(id);
        //     // if (userToDelete == null)
        //     //     return NotFound("Användaren hittades inte"); // 404

        //     // await _userManager.DeleteAsync(userToDelete);
        //     // return StatusCode(204, "Användaren är borttagen från systemet");

        //      var userToDelete = await _studentRepo.GetStudentByIdAsync(id);
        //         if (userToDelete == null)
        //             return NotFound("Användaren hittades inte"); // 404

        //         bool deleteSuccess = await _studentRepo.DeleteUserAsync(userToDelete);
        //         return (deleteSuccess)
        //             ? Ok() 
        //             : StatusCode(500, "Fail: Delete appUser"); 
        // }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult> AddCourseToStudent(int courseId)
        // {
        //     await _studentRepo.AddCourseToStudent(courseId, _userHelper.GetUserId());
        //     if(await _studentRepo.SaveAllAsync())
        //     {
        //         return StatusCode(204, "Användaren är uppdaterad");
        //     }
        //     return StatusCode(500, "Ett fel har inträffat");
        // }
        
    }
}