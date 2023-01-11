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
using Courses_Api.ViewModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;
        
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TeacherRepository(EducationContext context, IMapper mapper, UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddTeacherAsync(PostTeacherViewModel teacher)
        {
            var competence = _context.Competences.Include(c => c.Teachers).Where(
               c => c.Name!.ToLower() == teacher.Competence!.ToLower()).SingleOrDefault();

                if(competence is null)
            {
                 throw new Exception($"Kompetensen {teacher.Competence} finns inte i systemet.");
            }

            var teacherToAdd = _mapper.Map<Teacher>(teacher);
           teacherToAdd.CompetenceName = competence;
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

        public async Task<TeacherViewModel?> GetTeacherByIdAsync(int id)
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

        public async Task UpdateTeacherAsync(int id, PutTeacherViewModel teacher)
        {
            var teacherToUpdate = await _context.Teachers.FindAsync(id);

            if(teacherToUpdate is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            teacherToUpdate.Firstname = teacher.Firstname;
            teacherToUpdate.Lastname = teacher.Lastname;
            teacherToUpdate.Email = teacher.Email;
            teacherToUpdate.PhoneNumber = teacher.PhoneNumber;
            teacherToUpdate.Street = teacher.Street;
            teacherToUpdate.StreetNumber = teacher.StreetNumber;
            teacherToUpdate.PostalCode = teacher.PostalCode;
            teacherToUpdate.City = teacher.City;

            _context.Teachers.Update(teacherToUpdate);
        }
    }
}