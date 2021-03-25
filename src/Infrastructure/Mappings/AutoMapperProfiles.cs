using AutoMapper;
using CORE.DTOs;
using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserSystem, UserSystemDto>().ReverseMap();
            //CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
