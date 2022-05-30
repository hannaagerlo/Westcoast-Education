using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Student;

namespace Courses_Api.Interface
{
    public interface IStudentRepository
    {
         public Task<List<StudentViewModel>> ListAllCoursesAsync();
        public Task<StudentViewModel?> GetCourseAsync(string category);
        public Task AddCourseAsync(PostStudentViewModel course);
        public Task UpdateCourseAsync(int id, PostStudentViewModel course);
        public Task DeleteCourseAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}