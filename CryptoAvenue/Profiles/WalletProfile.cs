using AutoMapper;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.WalletDtos;

namespace CryptoAvenue.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletGetDto, Wallet>()
                .ForMember(d => d.Id, opt => opt.MapFrom(w => w.Id))
                .ForMember(d => d.CoinType, opt => opt.MapFrom(w => w.Coin))
                .ForMember(d => d.CoinID, opt => opt.MapFrom(w => w.CoinID))
                .ForMember(d => d.UserID, opt => opt.MapFrom(w => w.UserID))
                .ForMember(d => d.WalletOwner, opt => opt.MapFrom(w => w.WalletOwner))
                .ForMember(d => d.CoinAmount, opt => opt.MapFrom(w => w.CoinAmount))
                .ReverseMap();

            CreateMap<WalletPutPostDto, Wallet>()
                .ForMember(d => d.CoinID, opt => opt.MapFrom(w => w.CoinID))
                //.ForMember(d => d.CoinType, opt => opt.MapFrom(w => w.Coin))
                .ForMember(d => d.UserID, opt => opt.MapFrom(w => w.UserID))
                //.ForMember(d => d.WalletOwner, opt => opt.MapFrom(w => w.WalletOwner))
                .ForMember(d => d.CoinAmount, opt => opt.MapFrom(w => w.CoinAmount))
                .ReverseMap();
        }
    }
}
