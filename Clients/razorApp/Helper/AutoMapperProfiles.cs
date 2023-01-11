using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using razorApp.ViewModels;
using AutoMapper;

namespace razorApp.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StudentViewModel, UpdateStudentViewModel>();
            // .ForMember(dest => dest.Id, options => options.MapFrom(src => src.UserId));


            //  .ForMember(dest => dest.UserId, options => options.MapFrom(src => src.Id))
            // .ForMember(dest => dest.Name, options => options.MapFrom(src => string.Concat(
            //     src.FirstName, " ", src.LastName)))
            // .ForMember(dest => dest.Address, options => options.MapFrom(src => string.Concat(
            //     src.Street, " ", src.StreetNumber, ", ",src.PostalCode, " ", src.City)));
        }
    }
}