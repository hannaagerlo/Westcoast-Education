using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Interface;
using Courses_Api.ViewModel.Student;

namespace Courses_Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task AddCourseAsync(PostStudentViewModel course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentViewModel?> GetCourseAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentViewModel>> ListAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseAsync(int id, PostStudentViewModel course)
        {
            throw new NotImplementedException();
        }
    }
}