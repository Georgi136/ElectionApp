using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEnd.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Data.Models.Member, Data.DTO.Member>()
                .ReverseMap();
        }
    }
}
