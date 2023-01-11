using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Courses_Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
           private readonly IConfiguration _config;
        public UserRepository(EducationContext context, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config )
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

         public async Task<List<UserViewModel>> ListAllAdminsAsync()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin") as List<User> ?? new List<User>();

            var id = admins.Select(s => s.Id);
            return await _context.Users
                .Where(s => id.Contains(s.Id))
                .OrderBy(s => s.LastName!.ToLower())
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        // public async Task AddStudentAsync(PostUserViewModel student)
        // {
        //     var studentToAdd = _mapper.Map<User>(student);
        //    await _userManager.CreateAsync(studentToAdd);
        // }
        public async Task DeleteStudentAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if(userToDelete is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            if(userToDelete is not null)
            {
                await _userManager.DeleteAsync(userToDelete);
            }
        }
         public async Task UpdateStudentAsync(int id, PostUserViewModel model)
        {
            var userToUpdate = await _context.Users.FindAsync(id);

            if(userToUpdate is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            userToUpdate.FirstName = model.FirstName;
            userToUpdate.LastName = model.LastName;
            userToUpdate.Email = model.Email;
            userToUpdate.PhoneNumber = model.PhoneNumber;
            userToUpdate.Street = model.Street;
            userToUpdate.StreetNumber = model.StreetNumber;
            userToUpdate.PostalCode = model.PostalCode;
            userToUpdate.City = model.City;

            await _userManager.UpdateAsync(userToUpdate);
        }

         public async Task<bool> AddUserAsync(User model)
        {
            var userToAdd = await _userManager.CreateAsync(model);
            return userToAdd.Succeeded;
        }
        public async Task<bool> DeleteUserAsync(User model)
        {
            var result = await _userManager.DeleteAsync(model);
            return result.Succeeded;
        }





        // public async Task AddStudentAsync(PostUserViewModel student)
        // {
        //     var studentToAdd = _mapper.Map<User>(student);
        //    await _userManager.CreateAsync(studentToAdd);
        // }
        // // public async Task DeleteStudentAsync(string id)
        // // {
        // //     var studentToDelete = await _context.Users.FindAsync(id);
        // //     if(studentToDelete is null)
        // //     {
        // //         throw new Exception($"Det finns ingen användare med id: {id}");
        // //     }
        // //     if(studentToDelete is not null)
        // //     {
        // //         await _userManager.DeleteAsync(studentToDelete);
        // //     }
        // // }
        // public async Task<bool> DeleteUserAsync(UserViewModel model)
        // {
        //     var studentToDelete = _mapper.Map<User>(model);
        //     var result = await _userManager.DeleteAsync(studentToDelete);
        //     return result.Succeeded;
        // }
        //  public async Task UpdateStudentAsync(string id, PostUserViewModel student)
        // {
        //     var studentToUpdate = await _context.Users.FindAsync(id);

        //     if(studentToUpdate is null)
        //     {
        //         throw new Exception($"Det finns ingen användare med id: {id}");
        //     }
        //     studentToUpdate.FirstName = student.FirstName;
        //     studentToUpdate.LastName = student.LastName;
        //     studentToUpdate.Email = student.Email;
        //     studentToUpdate.PhoneNumber = student.PhoneNumber;
        //     studentToUpdate.Street = student.Street;
        //     studentToUpdate.StreetNumber = student.StreetNumber;
        //     studentToUpdate.PostalCode = student.PostalCode;
        //     studentToUpdate.City = student.City;

        //     await _userManager.UpdateAsync(studentToUpdate);
        // }

        // public async Task<UserViewModel?> GetStudentByIdAsync(string id)
        // {
        //     return await _context.Users.Where(s => s.Id == id)
        //     .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
        //     .SingleOrDefaultAsync();
        // }
        // public async Task<List<UserViewModel>> ListAllStudentsAsync()
        // {
        //     var students = await _userManager.GetUsersInRoleAsync("Student") as List<User> ?? new List<User>();

        //     var id = students.Select(s => s.Id);
        //     return await _context.Users
        //         .Where(s => id.Contains(s.Id))
        //         .OrderBy(s => s.LastName!.ToLower())
        //         .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
        //         .ToListAsync();
        // }
        // public async Task AddCourseToStudent(PostStudentCourseViewModel model)
        // {
        //     var studentCourseToAdd = _mapper.Map<StudentCourse>(model);
        //     studentCourseToAdd.HasRegistered = true;
        //     await _context.StudentCourse.AddAsync(studentCourseToAdd);
        // }
        // public async Task SetRoleAsync(User user, string role)
        // {
        //     if (await _roleManager.RoleExistsAsync(role) && !(await _userManager.IsInRoleAsync(user, role)))
        //     {
        //         await _userManager.AddToRoleAsync(user, role);
        //     }
        // }
        // public async Task<List<StudentCourse>> GetStudentWithCoursesAsync(string studentId)
        // {
        //     return await _context.StudentCourse
        //         .Where(sc => sc.StudentId == studentId)
        //         .ToListAsync();
        // }

        // public async Task<List<StudentRegisteredCoursesViewModel>> ListAllStudentWithCoursesAsync()
        // {
        //     return await _context.StudentCourse.ProjectTo<StudentRegisteredCoursesViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        // }

       
        // public async Task<List<string>> GetRolesByUserAsync(User user)
        // {
        //     return await _userManager.GetRolesAsync(user) as List<string> ?? new List<string>() {""};
        // }
    }


    }
