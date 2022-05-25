using Courses_Api.Models;

namespace Courses_Api.Interface
{
    public interface ICoursesRepository
    {
        public Task<List<Course>> ListAllCoursesAsync();
        public Task<Course> GetCourseAsync(string category);
        public Task AddCourseAsync(Course course);
        public Task<bool> SaveAllAsync();

        
    }
}