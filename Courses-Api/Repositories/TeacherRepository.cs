using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.ViewModel.Teacher;

namespace Courses_Api.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;
        public TeacherRepository(CourseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task AddTeacherAsync(PostTeacherViewModel teacher)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherViewModel?> GetTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherViewModel>> ListAllTeachersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(int id, PostTeacherViewModel teacher)
        {
            throw new NotImplementedException();
        }
    }
}