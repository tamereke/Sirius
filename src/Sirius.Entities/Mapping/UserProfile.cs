using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sirius.Core.Mapping;
using Sirius.Entities.Models;

namespace Sirius.Entities.Mapping
{
    public class UserProfile : Profile, IProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.FullName,
               opts => opts.MapFrom(src => string.Format("{0} {1}", src.Name, src.Surname)));
            CreateMap<UserDto, User>();
        }
    }
}
