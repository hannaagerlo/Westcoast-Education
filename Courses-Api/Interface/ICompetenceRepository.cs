using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Courses_Api.ViewModel.Competence;

namespace Courses_Api.Interface
{
    public interface ICompetenceRepository
    {
        public Task<bool> SaveAllAsync();
        //public Task AddCompetenceAsync(PostCompetenceViewModel competence);
        public Task AddCompetenceAsync(PostCompetenceViewModel model);
        public Task<List<CompetenceViewModel>> ListAllCompentencesAsync();
        public Task<CompetenceViewModel> GetCompetenceAsync(int id);
    }
}