using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Interface;
using Courses_Api.ViewModel.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Api.Controllers
{
    [ApiController]
    [Route("api/v1/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherController(ITeacherRepository teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherViewModel>>> ListTeachers()
        {
             return Ok(await _teacherRepo.ListAllTeachersAsync());        
        }

        // Sök/lista lärare efter Id nummer. 

    
        //POST
        [HttpPost]
        public async Task<ActionResult> AddSTeacher(PostTeacherViewModel teacher)
        {
            // måste lägga in felhantering, ska inte gå att spara en kurs med samma kursnummer.
                await _teacherRepo.AddTeacherAsync(teacher);
                if (await _teacherRepo.SaveAllAsync())
                {
                    return StatusCode(201);
                }
                return StatusCode(500, "Det gick inte att spara den nya användaren");
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeacherAsync(int id, PostTeacherViewModel teacher)
        {
            await _teacherRepo.UpdateTeacherAsync(id, teacher);
            if(await _teacherRepo.SaveAllAsync())
            {
                return StatusCode(204, "Användaren är uppdaterad");
            }
            return StatusCode(500, "Ett fel inträffade när användaren skulle uppdateras");


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherAsync(int id)
        {
            await _teacherRepo.DeleteTeacherAsync(id);
            if(await _teacherRepo.SaveAllAsync())
            {
                return StatusCode(204, "Användaren är bort tagen från systemet");
            }
            return StatusCode(500, "Ett fel inträffade när användaren skulle tas bort");
        }
    }
}