using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Teacher;
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Identity;
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
        // [HttpGet("{id}")]
        // public async Task<ActionResult<List<TeacherViewModel>>> GetTeacherById(int id)
        // {
        //     var response = await _teacherRepo.GetTeacherByIdAsync(id);
            
        //     if(response is null)
        //     return NotFound($"Det gick inte att hitta några kurser med kategorin: {id}");

        //     return Ok(response);
        // }  
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherViewModel>> GetTeacherById(int id)
        {
            var response = await _teacherRepo.GetTeacherByIdAsync(id);
            
            if(response is null)
            return NotFound($"Det gick inte att hitta nåhon lärare med id: {id}");

            return Ok(response);
        } 
    
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
        public async Task<ActionResult> UpdateTeacherAsync(int id, PutTeacherViewModel teacher)
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