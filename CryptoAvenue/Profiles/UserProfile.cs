using AutoMapper;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.UserDtos;

namespace CryptoAvenue.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserGetDto, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(u =>u.Password))
                .ForMember(d => d.SecurityQuestion, opt => opt.MapFrom(u => u.SecurityQuestion))
                .ForMember(d => d.SecurityAnswer, opt => opt.MapFrom(d => d.SecurityAnswer))
                .ForMember(d => d.PrivateProfile, opt => opt.MapFrom(u => u.PrivateProfile))
                .ReverseMap();

            CreateMap<UserPutPostDto, User>()
                .ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(d => d.Age, opt => opt.MapFrom(u => u.Age))
                .ForMember(d => d.SecurityQuestion, opt => opt.MapFrom(u => u.SecurityQuestion))
                .ForMember(d => d.SecurityAnswer, opt => opt.MapFrom(u => u.SecurityAnswer))
                .ForMember(d => d.PrivateProfile, opt => opt.MapFrom(u => u.PrivateProfile))
                .ReverseMap();
        }
    }
}
