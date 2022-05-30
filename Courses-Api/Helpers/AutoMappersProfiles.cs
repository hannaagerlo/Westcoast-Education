using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Student;

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
            .ForMember(dest => dest.StudentId, options => options.MapFrom(src => src.Id));
        }
    }
}