using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Courses;

namespace Courses_Api.Interface
{
    public interface ICoursesRepository
    {
        public Task<List<CourseViewModel>> ListAllCoursesAsync();
         public Task<List<CourseWithTeacherViewModel>> ListAllCoursesWithTeacherAsync();
        //public Task<List<CourseViewModel>> GetCourseAsync(string category);
        public Task<CourseViewModel?> GetCourseByIdAsync(int id);
        public Task AddCourseAsync(PostCourseViewModel course);
        public Task UpdateCourseAsync(int id, PutCourseViewModel course);
        public Task DeleteCourseAsync(int id);
         Task SignUpForCourses(string userName, int courseId);
        public Task<bool> SaveAllAsync();

        
    }
}