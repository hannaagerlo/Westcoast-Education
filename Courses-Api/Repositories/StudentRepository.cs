using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Student;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(CourseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddStudentAsync(PostStudentViewModel student)
        {
            var studentToAdd = _mapper.Map<Student>(student);
           await _context.Students.AddAsync(studentToAdd); 
        }

        public Task DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentViewModel?> GetStudentAsync(int id)
        {
            return await _context.Students.Where(c => c.Id == id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public Task<List<StudentViewModel>> ListAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task UpdateStudentAsync(int id, PostStudentViewModel student)
        {
            throw new NotImplementedException();
        }
    }
}