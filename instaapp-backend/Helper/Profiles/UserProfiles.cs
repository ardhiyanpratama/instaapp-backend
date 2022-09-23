using AutoMapper;
using HashidsNet;
using instaapp_backend.Dto;
using instaapp_backend.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace instaapp_backend.Helper.Profiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles(IHashids hashids)
        {

            CreateMap<User, UserReadDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => hashids.EncodeLong(src.Id))
                );

            CreateMap<UserWriteDto, User>();
        }
    }
}
