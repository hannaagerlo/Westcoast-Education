using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CustomerInterface.Models;
using CustomerInterface.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerInterface.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class AdminController : Controller
    {
       private readonly IConfiguration _config;
        private readonly CourseServiceModel _courseService;
        public AdminController(IConfiguration config)
        {
            _config = config;
            _courseService = new CourseServiceModel(_config);
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
           try{

               var courses = await _courseService.ListAllCourses();
               return View("Index", courses);

           }
           catch(System.Exception)  
           {
               throw;
           }
            
        }
        

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}