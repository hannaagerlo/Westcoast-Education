using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel.Teacher;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;
        public TeacherRepository(EducationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddTeacherAsync(PostTeacherViewModel teacher)
        {
            var teacherToAdd = _mapper.Map<Teacher>(teacher);
           await _context.Teachers.AddAsync(teacherToAdd); 
        }

        public async Task DeleteTeacherAsync(int id)
        {
           var response = await _context.Teachers.FindAsync(id);
            if(response is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            if(response is not null)
            {
                _context.Teachers.Remove(response);
            }
        }

        public async Task<TeacherViewModel?> GetTeacherAsync(int id)
        {
            return await _context.Teachers.Where(s => s.Id == id)
            .ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<List<TeacherViewModel>> ListAllTeachersAsync()
        {
            return await _context.Teachers.ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateTeacherAsync(int id, PostTeacherViewModel teacher)
        {
            var teacherToUpdate = await _context.Teachers.FindAsync(id);

            if(teacherToUpdate is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            teacherToUpdate.Firstname = teacher.Firstname;
            teacherToUpdate.Lastname = teacher.Lastname;
            teacherToUpdate.EmailAdress = teacher.EmailAdress;
            teacherToUpdate.PhoneNumber = teacher.PhoneNumber;
            teacherToUpdate.StreetAddress = teacher.StreetAddress;
            teacherToUpdate.PostalCode = teacher.PostalCode;
            teacherToUpdate.Municipality = teacher.Municipality;


            _context.Teachers.Update(teacherToUpdate);
        }
    }
}