using AutoMapper;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos;

namespace CryptoAvenue.Profiles
{
    public class CoinProfile : Profile
    {
        public CoinProfile()
        {
            CreateMap<CoinPutPostDto, Coin>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Abreviation, opt => opt.MapFrom(s => s.Abreviation))
                .ForMember(c => c.ValueInEUR, opt => opt.MapFrom(s => s.ValueInEUR))
                .ForMember(c => c.ValueInUSD, opt => opt.MapFrom(s => s.ValueInUSD))
                .ForMember(c => c.ValueInBTC, opt => opt.MapFrom(s => s.ValueInBTC))
                .ReverseMap();

            CreateMap<CoinGetDto, Coin>()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(c => c.Abreviation, opt => opt.MapFrom(s => s.Abreviation))
                .ForMember(c => c.ValueInEUR, opt => opt.MapFrom(s => s.ValueInEUR))
                .ForMember(c => c.ValueInUSD, opt => opt.MapFrom(s => s.ValueInUSD))
                .ForMember(c => c.ValueInBTC, opt => opt.MapFrom(s => s.ValueInBTC))
                .ReverseMap();
        }
    }
}
