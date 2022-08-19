using CustomerInterface.Models;
using CustomerInterface.ViewModels;
using CustomerInterface.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInterface.Controllers
{
    [Route("teacher")]
    public class TeacherController : Controller
    {
        private readonly IConfiguration _config;
        private readonly TeacherServiceModel _teacherService;
        public TeacherController(IConfiguration config)
        {
            _config = config;
            _teacherService = new TeacherServiceModel(_config);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var teacher =  new CreateTeacherViewModel();
            return View("Register", teacher);
        }
         [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateTeacherViewModel teacher){

            if(!ModelState.IsValid)
            {
                return View("Register", teacher);
            }

            if(await _teacherService.CreateTeacher(teacher))
            {
                return View("Confirmation");
            }
            return View("Register", teacher);
        }

        // [HttpGet()]
        // public async Task<IActionResult> Index() 
        // {
        //    try{

        //        var teachers = await _teacherService.ListAllTeachers();
        //        return View("Index", teachers);

        //    }
        //    catch(System.Exception)
        //    {
        //        throw;
        //    }
            
        // }
        [HttpGet()]
        public async Task<IActionResult> Index() 
        {
           try{

               var teachers = await _teacherService.ListAllTeachers();
               return View("Index", teachers);

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
                var model = await _teacherService.GetTeacherById(id);
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
                await _teacherService.DeleteTeacher(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", _teacherService.GetTeacherById(id));
            }
        }
        
    }
}