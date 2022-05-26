using Courses_Api.Models;
using Courses_Api.ViewModel;

namespace Courses_Api.Interface
{
    public interface ICoursesRepository
    {
        public Task<List<CourseViewModel>> ListAllCoursesAsync();
        public Task<CourseViewModel?> GetCourseAsync(string category);
        public Task AddCourseAsync(PostCoursesViewModel course);
        public Task UpdateCourseAsync(int id, PostCoursesViewModel course);
        public Task DeleteCourseAsync(int id);
        public Task<bool> SaveAllAsync();

        
    }
}