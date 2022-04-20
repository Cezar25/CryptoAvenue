using ConsoleProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.EntityConfigurations
{
    public class TradeOfferEntityTypeConfiguration : IEntityTypeConfiguration<TradeOffer>
    {
        public void Configure(EntityTypeBuilder<TradeOffer> builder)
        {
            //Configuring coins in offer
            builder
                .HasOne(offer => offer.SentCoin)
                .WithMany(coin => coin.OffersSent)
                .HasForeignKey(offer => offer.SentCoinID)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(offer => offer.ReceivedCoin)
                .WithMany(coin => coin.OffersReceived)
                .HasForeignKey(offer => offer.ReceivedCoinID)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuring users in offer
            builder
                .HasOne(offer => offer.Sender)
                .WithMany(user => user.OffersSent)
                .HasForeignKey(offer => offer.SenderID)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(offer => offer.Recipient)
                .WithMany(user => user.OffersReceived)
                .HasForeignKey(offer => offer.RecipientID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
