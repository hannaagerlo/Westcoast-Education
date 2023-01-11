using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Courses_Api.Models;
using Courses_Api.ViewModel;
using Courses_Api.ViewModel.Authorization;
using Courses_Api.ViewModel.Categories;
using Courses_Api.ViewModel.Competence;
using Courses_Api.ViewModel.Courses;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.StudentCourse;
using Courses_Api.ViewModel.Teacher;
using Courses_Api.ViewModel.Users;

namespace Courses_Api.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<PostCourseViewModel, Course>();
            CreateMap<PutCourseViewModel, Course>();
            CreateMap<Course, CourseViewModel>()
             .ForMember(dest => dest.CourseId, options => options.MapFrom(src => src.Id));
            CreateMap<Course, CourseWithTeacherViewModel>()
            .ForMember(dest => dest.CourseId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.CategoryName, options => options.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.TeacherId, options => options.MapFrom(src => src.TeacherId));

            CreateMap<PostUserViewModel, User>()
             .ForMember(dest => dest.IsLoggedIn, options => options.MapFrom(src => src.IsLoggedIn));
            CreateMap<PutUserViewModel, User>();
            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.UserId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, options => options.MapFrom(src => string.Concat(
                src.FirstName, " ", src.LastName)))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => string.Concat(
                src.Street, " ", src.StreetNumber, ", ",src.PostalCode, " ", src.City)));

            
            CreateMap<PostTeacherViewModel, Teacher>();
            CreateMap<PutTeacherViewModel, Teacher>();
            CreateMap<Teacher, TeacherViewModel>()
            .ForMember(dest => dest.TeacherId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, options => options.MapFrom(src => string.Concat(
                src.Firstname, " ", src.Lastname)))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => string.Concat(
                src.Street, ", ", src.StreetNumber, ", ",src.PostalCode, " ", src.City)))
            .ForMember(dest => dest.Competence, options => options.MapFrom(src => src.CompetenceName.Name));

             CreateMap<PostStudentViewModel, Student>()
             .ForMember(dest => dest.IsLoggedIn, options => options.MapFrom(src => src.IsLoggedIn));

            CreateMap<Student, StudentViewModel>()
            .ForMember(dest => dest.StudentId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, options => options.MapFrom(src => string.Concat(
                src.Firstname, " ", src.Lastname)))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => string.Concat(
                src.Street, ", ", src.StreetNumber, ", ",src.PostalCode, " ", src.City)));


            CreateMap<PostCategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>()
             .ForMember(dest => dest.CategoryId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Category, options => options.MapFrom(src => src.Name));
            CreateMap<Category, CategoryWithCoursesViewModel>()
            .ForMember(dest => dest.CategoryId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Category, options => options.MapFrom(src => src.Name))
            .ForMember(dest => dest.Courses, options => options.MapFrom(src => src.Courses));

             CreateMap<PostCompetenceViewModel, Competence>();
            CreateMap<Competence, CompetenceViewModel>()
            .ForMember(dest => dest.CompetenceId, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Competence, options => options.MapFrom(src => src.Name));

            //  CreateMap<PostStudentCourseViewModel, StudentCourse>();
            // CreateMap<StudentCourse, StudentRegisteredCoursesViewModel>()
            // .ForMember(dest => dest.StudentId, options => options.MapFrom(src => src.StudentId))
            // .ForMember(dest => dest.CourseNumber, options => options.MapFrom(src => src.Course.CourseNumber))
            // .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Course.Title));

            CreateMap<PostStudentCourseViewModel, StudentCourse>();
            CreateMap<StudentCourse, StudentCourseViewModel>()
            .ForMember(dest => dest.CourseNumber, options => options.MapFrom(src => src.Course.CourseNumber))
            .ForMember(dest => dest.Title, options => options.MapFrom(src => src.Course.Title));




        }
    }
}