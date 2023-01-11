using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Competence;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Api.Controllers
{
     [ApiController]
    [Route("api/v1/competences")]
    public class CompentenceController : ControllerBase
    {
        private readonly ICompetenceRepository _compRepo;
        private readonly IMapper _mapper;

        public CompentenceController(ICompetenceRepository compRepo, IMapper mapper)
        {
            _compRepo = compRepo;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> AddCompetenceAsync(PostCompetenceViewModel competence)
        {
            await _compRepo.AddCompetenceAsync(competence);
                if (await _compRepo.SaveAllAsync())
                {
                    return StatusCode(201);
                }
                return StatusCode(500, "Det gick inte att spara den nya kompetensen");

        
        }

        [HttpGet("list")]
        public async Task<ActionResult> ListAllCompetences()
        {
            var listCategories = await _compRepo.ListAllCompentencesAsync();
            return Ok(listCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompetenceById(int id)
        {
            return Ok(await _compRepo.GetCompetenceAsync(id));
        }

        
    }
}