using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Competence;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;

        public CompetenceRepository(EducationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        public async Task AddCompetenceAsync(PostCompetenceViewModel model)
        {
            var compToAdd = _mapper.Map<Competence>(model);
           await _context.Competences.AddAsync(compToAdd); 
        }

        public async Task<List<CompetenceViewModel>> ListAllCompentencesAsync()
        {
            return await _context.Competences.ProjectTo<CompetenceViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<CompetenceViewModel> GetCompetenceAsync(int id)
        {
           return _mapper.Map<CompetenceViewModel>(await _context.Competences.FindAsync(id));
        }

    }
}