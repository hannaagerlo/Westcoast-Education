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
        private readonly CourseContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(CourseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddCourseAsync(PostCoursesViewModel course)
        {
           var courseToAdd = _mapper.Map<Course>(course);
           await _context.Courses.AddAsync(courseToAdd); 
        }

        public async Task<CourseViewModel?> GetCourseAsync(string category)
        {
            return await _context.Courses.Where(c => c.Category == category)
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<List<CourseViewModel>> ListAllCoursesAsync()
        {
            return await _context.Courses.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}