using AutoMapper;
using CryptoAvenue.Domain.Models;
using CryptoAvenue.Dtos.TradeOfferDtos;

namespace CryptoAvenue.Profiles
{
    public class TradeOfferProfile : Profile
    {
        public TradeOfferProfile()
        {
            CreateMap<TradeOfferGetDto, TradeOffer>()
                .ForMember(t => t.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(t => t.SentAmount, opt => opt.MapFrom(d => d.SentAmount))
                .ForMember(t => t.ReceivedAmount, opt => opt.MapFrom(d =>d.ReceivedAmount))
                .ForMember(t => t.SenderID, opt => opt.MapFrom(d => d.SenderID))
                .ForMember(t => t.Sender, opt => opt.MapFrom(d => d.Sender))
                .ForMember(t => t.RecipientID, opt => opt.MapFrom(d =>d.RecipientID))
                .ForMember(t => t.Recipient, opt => opt.MapFrom(d => d.Recipient))
                .ForMember(t => t.SentCoinID, opt => opt.MapFrom(d => d.SentCoinID))
                .ForMember(t => t.SentCoin, opt => opt.MapFrom(d => d.SentCoin))
                .ForMember(t => t.ReceivedCoinID, opt => opt.MapFrom(d => d.ReceivedCoinID))
                .ForMember(t => t.ReceivedCoin, opt => opt.MapFrom(d => d.ReceivedCoin))
                .ReverseMap();

            CreateMap<TradeOfferPutPostDto, TradeOffer>()
                .ForMember(t => t.SentAmount, opt => opt.MapFrom(d => d.SentAmount))
                //.ForMember(t => t.ReceivedAmount, opt => opt.MapFrom(d => d.ReceivedAmount))
                .ForMember(t => t.SenderID, opt => opt.MapFrom(d => d.SenderID))
                .ForMember(t => t.RecipientID, opt => opt.MapFrom(d => d.RecipientID))
                .ForMember(t => t.SentCoinID, opt => opt.MapFrom(d => d.SentCoinID))
                .ForMember(t => t.ReceivedCoinID, opt => opt.MapFrom(d => d.ReceivedCoinID))
                .ReverseMap();

        }
    }
}
