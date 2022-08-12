using CustomerInterface.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // [HttpGet]
        // public async Task<IActionResult> Index() 
        // {
        //    try{

        //        var courses = await _courseService.ListAllCourses();
        //        return View("Index", courses);

        //    }
        //    catch(System.Exception)  
        //    {y
        //        throw;
        //    }
            
        // }
        [AllowAnonymous]
        public IActionResult AdminIndex()
        {
            return View();
        }

        //     [AllowAnonymous]
        //    [HttpGet("Create")]
        //     public async Task<IActionResult> CourseAdmin() 
        //     {
        //        try{

        //            var courses = await _courseService.ListAllCourses();
        //            return View("CourseAdmin", courses);

        //        }
        //        catch(System.Exception)
        //        {
        //            throw;
        //        }
                
        //     }
        
    }
}