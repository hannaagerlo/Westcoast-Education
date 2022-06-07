using CustomerInterface.Models;
using CustomerInterface.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInterface.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;
        private readonly StudentServiceModel _studentService;
        public StudentController(IConfiguration config)
        {
            _config = config;
            _studentService = new StudentServiceModel(_config);
        }

        [HttpGet()]
        public IActionResult Register()
        {
            var student =  new CreateStudentViewModel();
            return View("Register", student);
        }
         [HttpPost()]
        public async Task<IActionResult> Register(CreateStudentViewModel student){

            if(!ModelState.IsValid)
            {
                return View("Register", student);
            }

            if(await _studentService.CreateStudent(student))
            {
                return View("Confirmation");
            }
            return View("Register", student);
        }
    }
}