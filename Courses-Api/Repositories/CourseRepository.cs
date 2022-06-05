using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel;
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

        public async Task AddCourseAsync(PostCoursesViewModel course)
        {
           var courseToAdd = _mapper.Map<Course>(course);
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

        public async Task<List<CourseViewModel>> GetCourseAsync(string category)
        {
            return await _context.Courses.Where(c => c.Category!.ToLower() == category.ToLower())
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
             
        }   

        public async Task<List<CourseViewModel>> ListAllCoursesAsync()
        {
            return await _context.Courses.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
         public async Task UpdateCourseAsync(int id, PostCoursesViewModel course)
        {
            var courseToUpdate = await _context.Courses.FindAsync(id);

            if(courseToUpdate is null)
            {
                throw new Exception("Det finns ingen kurs med id: {id}");
            }
            courseToUpdate.CourseNumber = course.CourseNumber;
            courseToUpdate.Title = course.Title;
            courseToUpdate.Lenght = course.Lenght;
            courseToUpdate.Category = course.Category;
            courseToUpdate.Description = course.Description;
            courseToUpdate.Details = course.Details;
            courseToUpdate.ImageUrl = course.ImageUrl;

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
    }
}