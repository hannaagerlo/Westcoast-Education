using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Courses_Api.ViewModel.Categories;

namespace Courses_Api.Interface
{
    public interface ICategoryRepository
    {
        public Task AddCategoryAsync(PostCategoryViewModel model);
        public Task<bool> SaveAllAsync();
        public Task<List<CategoryViewModel>> ListAllCategoriesAsync();
        public Task<List<CategoryWithCoursesViewModel>> ListAllCategoriesWithCoursesAsync();
        public Task<CategoryWithCoursesViewModel?> GetCategoryAsync(int id);
        
       
    }
}