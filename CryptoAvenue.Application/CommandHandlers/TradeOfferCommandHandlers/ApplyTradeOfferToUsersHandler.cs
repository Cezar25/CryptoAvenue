using CryptoAvenue.Application.Commands.TradeOfferCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.TradeOfferCommandHandlers
{
    internal class ApplyTradeOfferToUsersHandler : IRequestHandler<ApplyTradeOfferToUsers>
    {
        private readonly ITradeOfferRepository tradeOfferRepository;
        private readonly IWalletRepository walletRepository;

        public ApplyTradeOfferToUsersHandler(ITradeOfferRepository tradeOfferRepository, IWalletRepository walletRepository)
        {
            this.tradeOfferRepository = tradeOfferRepository;
            this.walletRepository = walletRepository;
        }

        public Task<Unit> Handle(ApplyTradeOfferToUsers request, CancellationToken cancellationToken)
        {
            var tradeOffer = tradeOfferRepository.GetEntityByID(request.TradeOfferId);

            if (walletRepository.GetAll().Any(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.ReceivedCoin) && walletRepository.GetAll().Any(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.SentCoin))
            {
                var senderReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.ReceivedCoin);
                var recipientSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.SentCoin);

                senderReceivedWallet.CoinAmount += tradeOffer.ReceivedAmount;
                recipientSentWallet.CoinAmount += tradeOffer.SentAmount;

                var senderSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.SentCoin);
                var recipientReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.ReceivedCoin);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(senderReceivedWallet);
                walletRepository.Update(recipientSentWallet);
                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }
            else if (!walletRepository.GetAll().Any(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.ReceivedCoin) && walletRepository.GetAll().Any(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.SentCoin))
            {
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.ReceivedCoinID, UserID = tradeOffer.SenderID, CoinAmount = tradeOffer.ReceivedAmount });

                var recipientSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.SentCoin);
                recipientSentWallet.CoinAmount += tradeOffer.SentAmount;

                var senderSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.SentCoin);
                var recipientReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.ReceivedCoin);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(recipientSentWallet);
                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }
            else if (walletRepository.GetAll().Any(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.ReceivedCoin) && !walletRepository.GetAll().Any(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.SentCoin))
            {
                var senderReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.ReceivedCoin);

                senderReceivedWallet.CoinAmount += tradeOffer.ReceivedAmount;
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.SentCoinID, UserID = tradeOffer.RecipientID, CoinAmount = tradeOffer.SentAmount });

                var senderSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.SentCoin);
                var recipientReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.ReceivedCoin);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(senderReceivedWallet);
                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }
            else
            {
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.ReceivedCoinID, UserID = tradeOffer.SenderID, CoinAmount = tradeOffer.ReceivedAmount });
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.SentCoinID, UserID = tradeOffer.RecipientID, CoinAmount = tradeOffer.SentAmount });

                var senderSentWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.SenderID && x.CoinType == tradeOffer.SentCoin);
                var recipientReceivedWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == tradeOffer.RecipientID && x.CoinType == tradeOffer.ReceivedCoin);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }

            walletRepository.SaveChanges();

            tradeOfferRepository.Delete(tradeOffer);
            tradeOfferRepository.SaveChanges();

            return (Task<Unit>)Task.CompletedTask;
        }
    }
}
