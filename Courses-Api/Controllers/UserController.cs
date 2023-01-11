using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        //     [HttpGet]
        // public async Task<ActionResult<List<StudentViewModel>>> ListStudent()
        // {
        //      return Ok(await _studentRepo.ListAllStudentsAsync());        
        // }

        // [HttpPost("register")]
        // public async Task<ActionResult> RegisterStudentAsync(PostUserViewModel model)
        // {
        //     var userExist = await _userManager.FindByNameAsync(model.Email);
        //     if (userExist != null)
        //     {
        //         return StatusCode(500, "Användaren finns redan");
        //     }
        //     var user = new User{
        //         Email = model.Email!.ToLower(),
        //         UserName = model.Email!.ToLower(),
        //         FirstName = model.FirstName,
        //         LastName = model.LastName,
        //         PhoneNumber = model.PhoneNumber,
        //         Street = model.Street,
        //         StreetNumber = model.StreetNumber,
        //         City = model.City,
        //         PostalCode = model.PostalCode,
        //         IsLoggedIn = model.IsLoggedIn
        //     };

        //     var studentToAdd = await _userManager.CreateAsync(user, model.Password);
        //     user.EmailConfirmed = true;
        //     user.IsLoggedIn = true;

        //     if(!studentToAdd.Succeeded)
        //     {
        //          return StatusCode(500, "Det gick inte att spara användaren");
        //     }
        //       if (!await _roleManager.RoleExistsAsync(UserRole.Student))
        //     {
        //         await _roleManager.CreateAsync(new IdentityRole(UserRole.Student));
        //     }

        //     if (await _roleManager.RoleExistsAsync(UserRole.Student))
        //     {
        //         await _userManager.AddToRoleAsync(user, UserRole.Student);
        //     }

        //     return Ok("Användaren är sparad");

        // }
        // [HttpGet("getUser")]
        // public UserViewModel? LoggedInStudent()
        // {
        //     return _userHelper.LoggedInStudent();
        // }

        //  [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteStudentAsync(string id)
        // {
        //     var userToDelete = await _userManager.FindByIdAsync(id);
        //     if (userToDelete == null)
        //         return NotFound("Användaren hittades inte"); 

        //     await _userManager.DeleteAsync(userToDelete);
        //     if(userToDelete != null)
        //     {
        //         return StatusCode(500, "Användaren gick inte att ta bort");
        //     }
        //      return Ok("Användaren är borttagen från systemet");
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> UpdateStudentAsync(string id, PutUserViewModel model)
        // {
        //    //await _studentRepo.UpdateStudentAsync(id, student);
        //    var userToUpdate = await _userManager.FindByIdAsync(id);
        //    if (userToUpdate == null)
        //         return NotFound("Användaren hittades inte"); 

        //         _mapper.Map<PutUserViewModel, User>(model, userToUpdate);
        //         userToUpdate.UserName = userToUpdate.Email;

        //         await _userManager.UpdateAsync(userToUpdate);
        //         return Ok(userToUpdate.Id);

        
        // }
        //  [HttpGet("{id}")]
        // public async Task<ActionResult<List<StudentViewModel>>> GetStudentById(string id)
        // {
        //     var response = await _studentRepo.GetStudentByIdAsync(id);
            
        //     if(response is null)
        //     return NotFound($"Det gick inte att hitta en användare med id: {id}");

        //     return Ok(response);
        // }

        //  [HttpPost("registerToCourse")]
        // public async Task<ActionResult> RegisterStudentToCourse(PostStudentCourseViewModel model)
        // {
        //     // if(_signManager.IsSignedIn(User))
        //     // {
        //     //     await _studentRepo.AddCourseToStudent(model);
        //     //     if(await _studentRepo.SaveAllAsync())
        //     //     {
        //     //         return StatusCode(204, "Användaren är uppdaterad");
        //     //     }
        //     // }

        //     await _studentRepo.AddCourseToStudent(model);
        //         if(await _studentRepo.SaveAllAsync())
        //         {
        //             return StatusCode(204, "Användaren är uppdaterad");
        //         }
        //     return StatusCode(500, "Ingen användare är inloggad");
          
        // }

        // //  [HttpGet("getCourses/{studentId}")]
        // // public async Task<ActionResult<List<StudentCourseViewModel>>> GetStudentsRegistredCourses(string studentId)
        // // {
        // //     var studentCourses = await _studentRepo.GetStudentWithCoursesAsync(studentId);
		// // 	var models = _mapper.Map<List<StudentCourseViewModel>>(studentCourses);
			
		// // 	return Ok(models); 
        // // }

        // [HttpGet("getCourses/{studentId}")]
        // public async Task<ActionResult<List<StudentCourseViewModel>>> GetStudentsRegistredCourses(string studentId)
        // {
        //     var studentCourses = await _studentRepo.GetStudentWithCoursesAsync(studentId);
		// 	var models = _mapper.Map<List<StudentCourseViewModel>>(studentCourses);
			
		// 	return Ok(models); 
        // }

        // [HttpGet("listWithCourses")]
        // public async Task<ActionResult> ListAllStudentsWithCourses()
        // {
        //     var listCategories = await _studentRepo.ListAllStudentWithCoursesAsync();
        //     return Ok(listCategories);
        // }  [HttpGet]
        // public async Task<ActionResult<List<StudentViewModel>>> ListStudent()
        // {
        //      return Ok(await _studentRepo.ListAllStudentsAsync());        
        // }
        //        [HttpPost("register")]
        // public async Task<ActionResult> RegisterStudentAsync(PostUserViewModel model)
        // {
        //     var userExist = await _userManager.FindByNameAsync(model.Email);
        //     if (userExist != null)
        //     {
        //         return StatusCode(500, "Användaren finns redan");
        //     }
        //     var user = new User{
        //         Email = model.Email!.ToLower(),
        //         UserName = model.Email!.ToLower(),
        //         FirstName = model.FirstName,
        //         LastName = model.LastName,
        //         PhoneNumber = model.PhoneNumber,
        //         Street = model.Street,
        //         StreetNumber = model.StreetNumber,
        //         City = model.City,
        //         PostalCode = model.PostalCode,
        //         IsLoggedIn = model.IsLoggedIn
        //     };

        //     var studentToAdd = await _userManager.CreateAsync(user, model.Password);
        //     user.EmailConfirmed = true;
        //     user.IsLoggedIn = true;

        //     if(!studentToAdd.Succeeded)
        //     {
        //          return StatusCode(500, "Det gick inte att spara användaren");
        //     }
        //       if (!await _roleManager.RoleExistsAsync(UserRole.Student))
        //     {
        //         await _roleManager.CreateAsync(new IdentityRole(UserRole.Student));
        //     }

        //     if (await _roleManager.RoleExistsAsync(UserRole.Student))
        //     {
        //         await _userManager.AddToRoleAsync(user, UserRole.Student);
        //     }

        //     return Ok("Användaren är sparad");

        // }

        //  [HttpGet("getUser")]
        // public UserViewModel? LoggedInStudent()
        // {
        //     return _userHelper.LoggedInStudent();
        // }


        // [HttpPost]
        // public async Task<ActionResult> AddUserAsync(PostUserViewModel model)
        // {
        //     var userToAdd = _mapper.Map<User>(model);
        //     userToAdd.UserName = userToAdd.Email;
        //     bool createSuccess = await _userRepo.AddUserAsync(userToAdd);
        //     if (createSuccess && !string.IsNullOrEmpty(model.RoleName))
        //     {
        //         await _userRepo.SetRoleAsync(userToAdd, model.RoleName);
        //     }

        //     return (createSuccess)
        //         ? StatusCode(201, userToAdd.Id) // Created
        //         : StatusCode(500, "Fail: Create appUser"); // Internal server error
        // }
        // [HttpGet("GetRoles/{userId}")]
        // public async Task<ActionResult<string>> GetRolesUserAsync(string userId)
        // {
        //     var user = await _userRepo.GetUserAsync(userId);
        //     if (user == null)
        //         return NotFound($"Fail: Find user with id {userId}");

        //     var roleNames = await _userrepo.GetRoleNamesByAppUserAsync(appUser);
        //     return Ok(roleNames);
        // }
    }
}