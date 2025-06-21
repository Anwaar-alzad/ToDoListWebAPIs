using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DailyPilot.BLL.DTOs;
using DailyPilot.DAL.Entities;

namespace DailyPilot.BLL.Mappings
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserCreateDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
   
}
