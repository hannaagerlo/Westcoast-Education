using CustomerInterface.Models;
using CustomerInterface.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInterface.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;
        private readonly StudentServiceModel _studentService;
        public StudentController(IConfiguration config)
        {
            _config = config;
            _studentService = new StudentServiceModel(_config);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var student =  new CreateStudentViewModel();
            return View("Register", student);
        }
         [HttpPost("Register")]
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

         [HttpGet("Create")]
        public IActionResult Create()
        {
            var student =  new CreateStudentViewModel();
            return View("Create", student);
        }
         [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateStudentViewModel student){

            if(!ModelState.IsValid)
            {
                return View("Create", student);
            }

            if(await _studentService.CreateStudent(student))
            {
                return View("Confirmation");
            }
            return View("Create", student);
        }

         [HttpGet()]
        public async Task<IActionResult> Index() 
        {
           try{

               var students = await _studentService.ListAllStudents();
               return View("Index", students);

           }
           catch(System.Exception)
           {
               throw;
           }
            
        }
    }
}