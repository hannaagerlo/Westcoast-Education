using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Teacher;

namespace Courses_Api.Interface
{
    public interface ITeacherRepository
    {
        public Task<List<TeacherViewModel>> ListAllTeachersAsync();
        public Task<TeacherViewModel?> GetTeacherAsync(int id);
        public Task AddTeacherAsync(PostTeacherViewModel teacher);
        public Task UpdateTeacherAsync(int id, PostTeacherViewModel teacher);
        public Task DeleteTeacherAsync(int id);
        public Task<bool> SaveAllAsync();
    }
}