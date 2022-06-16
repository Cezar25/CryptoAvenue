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

        public async Task<Unit> Handle(ApplyTradeOfferToUsers request, CancellationToken cancellationToken)
        {
            var tradeOffer = tradeOfferRepository.GetEntityByID(request.TradeOfferId);

            var condition1 = walletRepository.Any(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.ReceivedCoinID);
            var condition2 = walletRepository.Any(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.SentCoinID);

            if (condition1 && condition2)
            {
                var senderReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.ReceivedCoinID);
                var recipientSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.SentCoinID);

                senderReceivedWallet.CoinAmount += tradeOffer.ReceivedAmount;
                recipientSentWallet.CoinAmount += tradeOffer.SentAmount;

                var senderSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.SentCoinID);
                var recipientReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.ReceivedCoinID);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(senderReceivedWallet);
                walletRepository.Update(recipientSentWallet);
                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }
            else if (!condition1 && condition2)
            {
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.ReceivedCoinID, UserID = tradeOffer.SenderID, CoinAmount = tradeOffer.ReceivedAmount });

                var recipientSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.SentCoinID);
                recipientSentWallet.CoinAmount += tradeOffer.SentAmount;

                var senderSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.SentCoinID);
                var recipientReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.ReceivedCoinID);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(recipientSentWallet);
                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }
            else if (condition1 && !condition2)
            {
                var senderReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.ReceivedCoinID);

                senderReceivedWallet.CoinAmount += tradeOffer.ReceivedAmount;
                walletRepository.Insert(new Wallet() { CoinID = tradeOffer.SentCoinID, UserID = tradeOffer.RecipientID, CoinAmount = tradeOffer.SentAmount });

                var senderSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.SentCoinID);
                var recipientReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.ReceivedCoinID);

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

                var senderSentWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.SenderID && x.CoinID == tradeOffer.SentCoinID);
                var recipientReceivedWallet = walletRepository.GetWalletByIncluded(x => x.UserID == tradeOffer.RecipientID && x.CoinID == tradeOffer.ReceivedCoinID);

                senderSentWallet.CoinAmount -= tradeOffer.SentAmount;
                recipientReceivedWallet.CoinAmount -= tradeOffer.ReceivedAmount;

                walletRepository.Update(senderSentWallet);
                walletRepository.Update(recipientReceivedWallet);
            }

            walletRepository.SaveChanges();

            tradeOfferRepository.Delete(tradeOffer);
            tradeOfferRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
