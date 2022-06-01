using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.Teacher;

namespace Courses_Api.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<PostCoursesViewModel, Course>();
            CreateMap<Course, CourseViewModel>()
            .ForMember(dest => dest.CourseId, options => options.MapFrom(src => src.Id));
            
            CreateMap<PostStudentViewModel, Student>();
            CreateMap<Student, StudentViewModel>()
            .ForMember(dest => dest.StudentId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.StudentName, options => options.MapFrom(src => string.Concat(src.Firstname, " ", src.Lastname)))
            .ForMember(dest => dest.Adress, options => options.MapFrom(src => string.Concat(src.StreetAddress, ", ", src.PostalCode, " ", src.Municipality)));

            CreateMap<PostTeacherViewModel, Teacher>();
            CreateMap<Teacher, TeacherViewModel>()
            .ForMember(dest => dest.TeacherId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.TeacherName, options => options.MapFrom(src => string.Concat(src.Firstname, " ", src.Lastname)))
            .ForMember(dest => dest.Adress, options => options.MapFrom(src => string.Concat(src.StreetAddress, ", ", src.PostalCode, " ", src.Municipality)));
        }
    }
}