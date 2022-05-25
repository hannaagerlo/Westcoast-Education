using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;

namespace Courses_Api.Repositories
{
    public class CourseRepository : ICoursesRepository
    {
        private readonly CourseContext _context;
        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public Task AddCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> ListAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}