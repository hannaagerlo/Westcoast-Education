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

           [HttpGet("GetDelete")]
        public async Task<ActionResult> GetDelete(int id)
        {
            try
            {
                var model = await _studentService.GetStudentById(id);
                return View("Delete", model);
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
                await _studentService.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", _studentService.GetStudentById(id));
            }
        }
        
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdEdit(id);
           
            return View("Edit", student);
        }

 
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditStudentViewModel student)
        {
            try
            {
                await _studentService.EditStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var editStudent = new EditStudentViewModel
                {
                    Firstname = student.Firstname,
                    Lastname = student.Lastname,
                    EmailAdress = student.EmailAdress,
                    PhoneNumber = student.PhoneNumber,
                    StreetAddress = student.StreetAddress,
                    PostalCode = student.PostalCode,
                    Municipality = student.Municipality

                };
                return View("Edit", editStudent);
            }
        }

        // [HttpGet("Edit")]
        // public async Task<IActionResult> Edit(int id)
        // {
        //     var student = await _studentService.GetStudentById(id);
           
        //     return View("Edit", student);
        // }

 
        // [HttpPost("Edit")]
        // public async Task<IActionResult> Edit(StudentViewModel student)
        // {
        //     try
        //     {
        //         await _studentService.EditStudent(student);
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         var editStudent = new StudentViewModel
        //         {
        //             StudentName = student.StudentName,
        //             EmailAdress = student.EmailAdress,
        //             PhoneNumber = student.PhoneNumber,
        //             Adress = student.Adress

        //         };
        //         return View("Edit", editStudent);
        //     }
        // }
        

            
        }
    }
