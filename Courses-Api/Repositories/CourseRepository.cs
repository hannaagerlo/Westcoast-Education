using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Courses;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class CourseRepository : ICoursesRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(EducationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddCourseAsync(PostCourseViewModel model)
        {
            // var category = _context.Categories.Include(cc => cc.Courses).Where(
            // c => c.Name!.ToLower() == model.CategoryName!.ToLower()).SingleOrDefault();

            var category = _context.Categories.Include(cc => cc.Courses).Where(
            c => c.Id == model.CategoryId).SingleOrDefault();

            var teacher = _context.Teachers.Include(cc => cc.Courses).Where(
            c => c.Id == model.TeacherId).SingleOrDefault();

            // if(category is null)
            // {
            //      throw new Exception($"Kategorin {model.CategoryName} finns inte i systemet.");
            // }
             if(category is null)
            {
                 throw new Exception($"Kategorin {model.CategoryId} finns inte i systemet.");
            }

           var courseToAdd = _mapper.Map<Course>(model);
           courseToAdd.Category = category;
           courseToAdd.Teachers = teacher;
           await _context.Courses.AddAsync(courseToAdd); 
        
        }

        public async Task DeleteCourseAsync(int id)
        {
            var response = await _context.Courses.FindAsync(id);
            if(response is null)
            {
                throw new Exception($"Det finns ingen kurs med id: {id}");
            }
            if(response is not null)
            {
                _context.Courses.Remove(response);
            }
        }

        // public async Task<List<CourseViewModel>> GetCourseAsync(string category)
        // {
        //     return await _context.Courses.Where(c => c.Category!.ToLower() == category.ToLower())
        //     .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
        //     .ToListAsync();
             
        // }   

        public async Task<List<CourseViewModel>> ListAllCoursesAsync()
        {
            return await _context.Courses.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<CourseWithTeacherViewModel>> ListAllCoursesWithTeacherAsync()
        {
            return await _context.Courses.ProjectTo<CourseWithTeacherViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
         public async Task UpdateCourseAsync(int id, PutCourseViewModel course)
        {
            var courseToUpdate = await _context.Courses.FindAsync(id);

            if(courseToUpdate is null)
            {
                throw new Exception("Det finns ingen kurs med id: {id}");
            }
            courseToUpdate.Title = course.Title;
            courseToUpdate.Lenght = course.Lenght;
            courseToUpdate.Description = course.Description;
            courseToUpdate.Details = course.Details;

            _context.Courses.Update(courseToUpdate);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Where(c => c.Id == id)
          .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
        }
        public async Task SignUpForCourses(string userEmail, int courseId)
        {
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);

            if (course is null)
                throw new FileNotFoundException("Finns ingen kurs med det nummer");

            // var student = _context.Students.SingleOrDefault(x => x.EmailAdress == userEmail);
            var student = _context.Students.SingleOrDefault(x => x.Email == userEmail);
            if (student is null)
                throw new FileNotFoundException("Finns ingen student med det användarnamnet");

            course.Students.Add(student);
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}