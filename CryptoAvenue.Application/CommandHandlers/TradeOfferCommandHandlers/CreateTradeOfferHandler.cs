using CryptoAvenue.Application.Commands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers
{
    public class CreateTradeOfferHandler : IRequestHandler<CreateTradeOffer, TradeOffer>
    {
        private readonly ITradeOfferRepository repository;
        private readonly ICoinRepository coinRepository;

        public CreateTradeOfferHandler(ITradeOfferRepository repository, ICoinRepository coinRepository)
        {
            this.repository = repository;
            this.coinRepository = coinRepository;
        }

        public Task<TradeOffer> Handle(CreateTradeOffer request, CancellationToken cancellationToken)
        {
            var tradeOffer = new TradeOffer()
            {
                SenderID = request.SenderId,
                RecipientID = request.RecipientId,
                SentCoinID = request.SentCoinId,
                ReceivedCoinID = request.ReceivedCoinId,
                SentAmount = request.SentAmount
            };

            //var tempOffer = repository.GetOffersByRecipientID(request.RecipientId).SingleOrDefault(x => x.SenderID == request.SenderId && x.SentCoinID == request.SentCoinId && x.ReceivedCoinID == request.ReceivedCoinId);

            Coin tempReceivedCoin = null;
            Coin tempSentCoin = null;

            try
            {
                tempReceivedCoin = coinRepository.GetAllCoinsByUserId(request.SenderId).FirstOrDefault(x => x.Id == request.SentCoinId);
                tempSentCoin = coinRepository.GetAllCoinsByUserId(request.RecipientId).FirstOrDefault(x => x.Id == request.ReceivedCoinId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

            /*var tempReceivedCoin = coinRepository.GetAllCoinsByUserId(request.SenderId).FirstOrDefault(x => x.Id == request.SentCoinId);
            var tempSentCoin = coinRepository.GetAllCoinsByUserId(request.RecipientId).FirstOrDefault(x => x.Id == request.ReceivedCoinId);*/

            tradeOffer.ReceivedAmount = (request.SentAmount * tempSentCoin.ValueInEUR) / tempReceivedCoin.ValueInEUR;

            //tradeOffer.ReceivedAmount = (tempOffer.SentAmount * tempOffer.SentCoin.ValueInEUR) / tempOffer.ReceivedCoin.ValueInEUR;

            if (tradeOffer == null) return null;

            repository.Insert(tradeOffer);
            repository.SaveChanges();

            return Task.FromResult(tradeOffer);

        }
    }
}
