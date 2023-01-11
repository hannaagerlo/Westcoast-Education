using Courses_Api.Models;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.StudentCourse;
using Courses_Api.ViewModel.Users;

namespace Courses_Api.Interface
{
    public interface IStudentRepository
    {

           public Task<List<StudentViewModel>> ListAllStudentsAsync();
        public Task<StudentViewModel?> GetStudentAsync(int id);
         public Task<StudentWithCoursesViewModel?> GetStudentWithCourses(int id);
        public Task AddStudentAsync(PostStudentViewModel student);
        public Task UpdateStudentAsync(int id, PostStudentViewModel student);
        public Task DeleteStudentAsync(int id);
        public Task AddCourseToStudent(int courseId, int studentId);
        
        //  public Task<List<UserViewModel>> ListAllStudentsAsync();
        // public Task<UserViewModel?> GetStudentByIdAsync(string id);
        //  //public Task<StudentWithCoursesViewModel?> GetStudentWithCourses(int id);
        // public Task AddStudentAsync(PostUserViewModel student);
        // public Task UpdateStudentAsync(string id, PostUserViewModel student);
        //  public Task<bool> DeleteUserAsync(UserViewModel model);
        // public Task AddCourseToStudent(PostStudentCourseViewModel model);
        // public Task<List<StudentCourse>> GetStudentWithCoursesAsync(string studentId);
        // public Task<List<StudentRegisteredCoursesViewModel>> ListAllStudentWithCoursesAsync();
    

        // public Task SetRoleAsync(User user, string role);
        // public Task<List<string>> GetRolesByUserAsync(User user);
        
        public Task<bool> SaveAllAsync();
    }
}