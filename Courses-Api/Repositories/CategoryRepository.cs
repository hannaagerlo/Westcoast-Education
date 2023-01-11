using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Categories;
using Courses_Api.ViewModel.Courses;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
         private readonly EducationContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(EducationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        public async Task AddCategoryAsync(PostCategoryViewModel model)
        {
            var categoryToAdd =  _mapper.Map<Category>(model);
            await _context.Categories.AddAsync(categoryToAdd);
        }

        public async Task<List<CategoryViewModel>> ListAllCategoriesAsync()
        {
            return await _context.Categories.ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

         public async Task<List<CategoryWithCoursesViewModel>> ListAllCategoriesWithCoursesAsync()
        {
            return await _context.Categories.ProjectTo<CategoryWithCoursesViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        // public async Task<CategoryWithCoursesViewModel> GetCategoryAsync(int id)
        // {
        //    return _mapper.Map<CategoryWithCoursesViewModel>(await _context.Competences.FindAsync(id));
        // }

         public async Task<CategoryWithCoursesViewModel?> GetCategoryAsync(int id)
        {
            return await _context.Categories.Where(e => e.Id == id).Include(e => e.Courses)
            .Select(s => new CategoryWithCoursesViewModel
            {
                CategoryId = s.Id,
                Category = s.Name,
                Courses = s.Courses
                .Select(c => new CourseViewModel
                {
                    CourseId = c.Id,
                    CourseNumber = c.CourseNumber,
                    Title = c.Title,
                    Lenght = c.Lenght
                }).ToList()
            })
            .SingleOrDefaultAsync();
        }

        // public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
        // {
        //     return await _context.Courses.Where(c => c.Id == id)
        //   .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
        //   .SingleOrDefaultAsync();
        // }
    }
}