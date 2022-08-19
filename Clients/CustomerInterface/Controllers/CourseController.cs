using CustomerInterface.Models;
using CustomerInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInterface.Controllers
{
    [Route("course")]
    public class CourseController : Controller
    {
        private readonly IConfiguration _config;
        private readonly CourseServiceModel _courseService;
        private readonly StudentServiceModel _studentService;
       
        public CourseController(IConfiguration config)
        {
            _config = config;
            _courseService = new CourseServiceModel(_config);
            
             _studentService = new StudentServiceModel(_config);
           
        }

        [HttpGet()]
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
        

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            try
            {
                var course = await _courseService.FindByIdCourse(id);
                return View("Details", course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
        }
        [HttpGet("Search/{category}")]
        public async Task<IActionResult> Search(string category)
        {

            try
            {
                var course = await _courseService.FindByCategory(category);
                return View("Search",course);
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var course =  new CreateCourseViewModel();
            return View("Create", course);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCourseViewModel course){

            if(!ModelState.IsValid)
            {
                return View("Create", course);
            }

            if(await _courseService.CreateCourse(course))
            {
                return View("Confirmation");
            }
            return View("Create", course);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> GetDelete(int id)
        {
            try
            {
                var course = await _courseService.FindByIdCourse(id);  
                return View("Delete", course);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {                
                await _courseService.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", _courseService.FindByIdCourse(id));
            }
        }

        
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.FindByIdCourse(id);
           
            return View("Edit", course);
        }

 
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(EditCourseViewModel course)
        {
            try
            {
                await _courseService.EditCourse(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var courseGetConvert = new EditCourseViewModel
                {
                    CourseNumber = course.CourseNumber,
                    Title = course.Title,
                    Lenght = course.Lenght,
                    Category = course.Category,
                    Description = course.Description,
                    Details = course.Details,
                    ImageUrl = course.ImageUrl
                };
                return View("Edit", courseGetConvert);
            }
        }
        // [HttpGet("signup")]
        // public async Task<IActionResult> SignUp(int id)
        // {
        //     try
        //     {
        //         if (await _studentService.GetStudent() is null)
        //             throw new Exception("Ingen inloggad användare");

        //         await _courseService.SignUp(id);
        //         return RedirectToAction("Index");
        //     }
        //     catch (Exception)
        //     {
        //         return RedirectToAction("Create", "Student");
        //     }
        // }

        [HttpGet("signup")]
        public async Task<IActionResult> SignUp(int id)
        {
            try
            {
                if (await _studentService.GetStudent() is null)
                    throw new Exception("Ingen inloggad användare");

                await _courseService.SignUp(id);
                return View("CourseConfirmation");
            }
            catch (Exception)
            {
                return RedirectToAction("Register", "Student");
            }
        }
       
    }
}