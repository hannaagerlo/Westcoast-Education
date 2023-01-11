using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Courses;
using Courses_Api.ViewModel.Student;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
         private readonly EducationContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StudentRepository(EducationContext context, IMapper mapper, UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager )
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddStudentAsync(PostStudentViewModel student)
        {
            student.IsLoggedIn = true;
            var studentToAdd = _mapper.Map<Student>(student);
           await _context.Students.AddAsync(studentToAdd); 
            
        }

        public async Task DeleteStudentAsync(int id)
        {
            var response = await _context.Students.FindAsync(id);
            if(response is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            if(response is not null)
            {
                _context.Students.Remove(response);
            }
        }

        public async Task<StudentViewModel?> GetStudentAsync(int id)
        {
            return await _context.Students.Where(s => s.Id == id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<StudentWithCoursesViewModel?> GetStudentWithCourses(int id)
        {
            return await _context.Students.Where(e => e.Id == id).Include(e => e.Courses)
            .Select(s => new StudentWithCoursesViewModel
            {
                StudentId = s.Id,
                StudentName = string.Concat(s.Firstname, " ", s.Lastname),
                EmailAdress = s.Email,
                PhoneNumber = s.PhoneNumber,
                Adress = string.Concat(s.Street, ", ", s.PostalCode, " ", s.City),
                Courses = s.Courses
                .Select(c => new CourseViewModel
                {
                    CourseId = c.Id,
                    CourseNumber = c.CourseNumber,
                    Title = c.Title,
                    Lenght = c.Lenght
                }).ToList()
            })
            .SingleOrDefaultAsync();
        }

        public async Task<List<StudentViewModel>> ListAllStudentsAsync()
        {
            return await _context.Students.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task UpdateStudentAsync(int id, PostStudentViewModel student)
        {
            var studentToUpdate = await _context.Students.FindAsync(id);

            if(studentToUpdate is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            studentToUpdate.Firstname = student.Firstname;
            studentToUpdate.Lastname = student.Lastname;
            studentToUpdate.Email = student.Email;
            studentToUpdate.PhoneNumber = student.PhoneNumber;
            studentToUpdate.Street = student.Street;
            studentToUpdate.StreetNumber = student.StreetNumber;
            studentToUpdate.PostalCode = student.PostalCode;
            studentToUpdate.City = student.City;


            _context.Students.Update(studentToUpdate);
        }
        public async Task AddCourseToStudent(int courseId, int studentId)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == studentId);
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);

            student.Courses.Add(course);
            _context.Students.Update(student);
            
        }
        


























    //     public async Task AddStudentAsync(PostUserViewModel student)
    //     {
    //         var studentToAdd = _mapper.Map<User>(student);
    //        await _userManager.CreateAsync(studentToAdd);
    //     }
    //     // public async Task DeleteStudentAsync(string id)
    //     // {
    //     //     var studentToDelete = await _context.Users.FindAsync(id);
    //     //     if(studentToDelete is null)
    //     //     {
    //     //         throw new Exception($"Det finns ingen användare med id: {id}");
    //     //     }
    //     //     if(studentToDelete is not null)
    //     //     {
    //     //         await _userManager.DeleteAsync(studentToDelete);
    //     //     }
    //     // }
    //     public async Task<bool> DeleteUserAsync(UserViewModel model)
    //     {
    //         var studentToDelete = _mapper.Map<User>(model);
    //         var result = await _userManager.DeleteAsync(studentToDelete);
    //         return result.Succeeded;
    //     }
    //      public async Task UpdateStudentAsync(string id, PostUserViewModel student)
    //     {
    //         var studentToUpdate = await _context.Users.FindAsync(id);

    //         if(studentToUpdate is null)
    //         {
    //             throw new Exception($"Det finns ingen användare med id: {id}");
    //         }
    //         studentToUpdate.FirstName = student.FirstName;
    //         studentToUpdate.LastName = student.LastName;
    //         studentToUpdate.Email = student.Email;
    //         studentToUpdate.PhoneNumber = student.PhoneNumber;
    //         studentToUpdate.Street = student.Street;
    //         studentToUpdate.StreetNumber = student.StreetNumber;
    //         studentToUpdate.PostalCode = student.PostalCode;
    //         studentToUpdate.City = student.City;

    //         await _userManager.UpdateAsync(studentToUpdate);
    //     }

    //     public async Task<UserViewModel?> GetStudentByIdAsync(string id)
    //     {
    //         return await _context.Users.Where(s => s.Id == id)
    //         .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
    //         .SingleOrDefaultAsync();
    //     }
    //     public async Task<List<UserViewModel>> ListAllStudentsAsync()
    //     {
    //         var students = await _userManager.GetUsersInRoleAsync("Student") as List<User> ?? new List<User>();

    //         var id = students.Select(s => s.Id);
    //         return await _context.Users
    //             .Where(s => id.Contains(s.Id))
    //             .OrderBy(s => s.LastName!.ToLower())
    //             .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
    //             .ToListAsync();
    //     }
    //     public async Task AddCourseToStudent(PostStudentCourseViewModel model)
    //     {
    //         var studentCourseToAdd = _mapper.Map<StudentCourse>(model);
    //         studentCourseToAdd.HasRegistered = true;
    //         await _context.StudentCourse.AddAsync(studentCourseToAdd);
    //     }
    //     public async Task SetRoleAsync(User user, string role)
    //     {
    //         if (await _roleManager.RoleExistsAsync(role) && !(await _userManager.IsInRoleAsync(user, role)))
    //         {
    //             await _userManager.AddToRoleAsync(user, role);
    //         }
    //     }
    //     public async Task<List<StudentCourse>> GetStudentWithCoursesAsync(string studentId)
    //     {
    //         return await _context.StudentCourse
    //             .Where(sc => sc.StudentId == studentId)
    //             .ToListAsync();
    //     }

    //     public async Task<List<StudentRegisteredCoursesViewModel>> ListAllStudentWithCoursesAsync()
    //     {
    //         return await _context.StudentCourse.ProjectTo<StudentRegisteredCoursesViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    //     }

       
    //     public async Task<List<string>> GetRolesByUserAsync(User user)
    //     {
    //         return await _userManager.GetRolesAsync(user) as List<string> ?? new List<string>() {""};
    //     }
    // }
    }
}