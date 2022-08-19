using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Student;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EducationContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(EducationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddStudentAsync(PostStudentViewModel student)
        {
            student.IsLoggedIn = true;
            var studentToAdd = _mapper.Map<Student>(student);
           await _context.Students.AddAsync(studentToAdd); 
            
        }

        public async Task DeleteStudentAsync(int id)
        {
            var response = await _context.Students.FindAsync(id);
            if(response is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            if(response is not null)
            {
                _context.Students.Remove(response);
            }
        }

        public async Task<StudentViewModel?> GetStudentAsync(int id)
        {
            return await _context.Students.Where(s => s.Id == id)
            .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<StudentWithCoursesViewModel?> GetStudentWithCourses(int id)
        {
            return await _context.Students.Where(e => e.Id == id).Include(e => e.Courses)
            .Select(s => new StudentWithCoursesViewModel
            {
                StudentId = s.Id,
                StudentName = string.Concat(s.Firstname, " ", s.Lastname),
                EmailAdress = s.EmailAdress,
                PhoneNumber = s.PhoneNumber,
                Adress = string.Concat(s.StreetAddress, ", ", s.PostalCode, " ", s.Municipality),
                Courses = s.Courses
                .Select(c => new CourseViewModel
                {
                    CourseId = c.Id,
                    CourseNumber = c.CourseNumber,
                    Title = c.Title,
                    Lenght = c.Lenght,
                    Category = c.Category,
                }).ToList()
            })
            .SingleOrDefaultAsync();
        }

        public async Task<List<StudentViewModel>> ListAllStudentsAsync()
        {
            return await _context.Students.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateStudentAsync(int id, PostStudentViewModel student)
        {
            var studentToUpdate = await _context.Students.FindAsync(id);

            if(studentToUpdate is null)
            {
                throw new Exception($"Det finns ingen användare med id: {id}");
            }
            studentToUpdate.Firstname = student.Firstname;
            studentToUpdate.Lastname = student.Lastname;
            studentToUpdate.EmailAdress = student.EmailAdress;
            studentToUpdate.PhoneNumber = student.PhoneNumber;
            studentToUpdate.StreetAddress = student.StreetAddress;
            studentToUpdate.PostalCode = student.PostalCode;
            studentToUpdate.Municipality = student.Municipality;


            _context.Students.Update(studentToUpdate);
        }
        public async Task AddCourseToStudent(int courseId, int studentId)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == studentId);
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);

            student.Courses.Add(course);
            _context.Students.Update(student);
            
        }
        
    }
}