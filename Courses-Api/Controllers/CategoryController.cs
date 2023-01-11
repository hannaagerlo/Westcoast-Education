using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _catRepo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository catRepo, IMapper mapper)
        {
            _catRepo = catRepo;
            _mapper = mapper;
        }

         [HttpPost]
        public async Task<ActionResult> AddCategoryAsync(PostCategoryViewModel model)
        {
            await _catRepo.AddCategoryAsync(model);

        // Anropa metoden SaveAllAsync i vårt repository för att spara ner ändringar i databasen.
        if (await _catRepo.SaveAllAsync())
        {
          // Returnera statuskoden 201(Created)
          return StatusCode(201);
        }

        // Om det inte gick att spara returnera ett server fel(500).
        return StatusCode(500, "Det gick fel när vi skulle spara tillverkaren");
        }

    //    [HttpGet("list")]
    //     public async Task<ActionResult> ListAllCategories()
    //     {
    //         var listCategories = await _catRepo.ListAllCategoriesAsync();
    //         return Ok(listCategories);
    //     }

    [HttpGet("list")]
        public async Task<ActionResult<List<CategoryViewModel>>> ListAllCategories()
        {
             return Ok(await _catRepo.ListAllCategoriesAsync());
        
        }

        [HttpGet("listWithCourses")]
        public async Task<ActionResult> ListAllCategoriesWithCourses()
        {
            var listCategories = await _catRepo.ListAllCategoriesWithCoursesAsync();
            return Ok(listCategories);
        }

        [HttpGet("filterByCategory/{id}")]
        public async Task<ActionResult<CategoryViewModel>> ListCategoryWithCourses(int id)
        {
            var response = await _catRepo.GetCategoryAsync(id);

            
            if (response is null)
                
                return NotFound($"Vi kunde inte hitta någon kurs med id: {id}");

            
            return Ok(response);
        }

    }
}