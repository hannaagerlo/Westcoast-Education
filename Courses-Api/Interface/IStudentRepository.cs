using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Student;

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
        public Task<bool> SaveAllAsync();
    }
}