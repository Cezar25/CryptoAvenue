using ConsoleProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class UserToUserTradeBusinessLogic
    {
        public static void ApplyTrade(TradeOffer offer)
        {
            var db = new CryptoAvenueContext();

            if (db.Wallets.Where(x => x.UserID == offer.Sender.UserID).Any(x => x.CoinType == offer.ReceivedCoin) && db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).Any(x => x.CoinType == offer.SentCoin))
            {
                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount += offer.ReceivedAmount;
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount += offer.SentAmount;

                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else if (!db.Wallets.Where(x => x.UserID == offer.Sender.UserID).Any(x => x.CoinType == offer.ReceivedCoin) && db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).Any(x => x.CoinType == offer.SentCoin))
            {
                db.Wallets.Add(new Wallet() { CoinID = offer.ReceivedCoin.CoinID, UserID = offer.Sender.UserID, CoinAmount = offer.ReceivedAmount });
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount += offer.SentAmount;

                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else if (db.Wallets.Where(x => x.UserID == offer.Sender.UserID).Any(x => x.CoinType == offer.ReceivedCoin) && !db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).Any(x => x.CoinType == offer.SentCoin))
            {
                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount += offer.ReceivedAmount;
                db.Wallets.Add(new Wallet() { CoinID = offer.SentCoin.CoinID, UserID = offer.Recipient.UserID, CoinAmount = offer.SentAmount });

                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }
            else
            {
                db.Wallets.Add(new Wallet() { CoinID = offer.ReceivedCoin.CoinID, UserID = offer.Sender.UserID, CoinAmount = offer.ReceivedAmount });
                db.Wallets.Add(new Wallet() { CoinID = offer.SentCoin.CoinID, UserID = offer.Recipient.UserID, CoinAmount = offer.SentAmount });

                db.Wallets.Where(x => x.UserID == offer.Sender.UserID).FirstOrDefault(x => x.CoinType == offer.SentCoin).CoinAmount -= offer.SentAmount;
                db.Wallets.Where(x => x.UserID == offer.Recipient.UserID).FirstOrDefault(x => x.CoinType == offer.ReceivedCoin).CoinAmount -= offer.ReceivedAmount;
            }

            db.SaveChanges();
        }
    }
}
