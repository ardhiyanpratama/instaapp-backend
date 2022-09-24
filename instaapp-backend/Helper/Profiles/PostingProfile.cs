using AutoMapper;
using HashidsNet;
using instaapp_backend.Dto;
using instaapp_backend.Models;

namespace instaapp_backend.Helper.Profiles
{
    public class PostingProfile : Profile
    {
        public PostingProfile(IHashids hashids)
        {

            CreateMap<Posting, PostingReadDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => hashids.EncodeLong(src.Id))
                );

            CreateMap<PostingWriteDto, Posting>();
        }
    }
}
