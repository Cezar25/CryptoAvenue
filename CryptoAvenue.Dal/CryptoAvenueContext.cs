using CryptoAvenue.Dal.EntityTypeConfigurations;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal
{
    public class CryptoAvenueContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<TradeOffer> Offers { get; set; }
        public CryptoAvenueContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=ROMOB41211\SQLEXPRESS01;Database=Test2DB;Trusted_Connection=True;", b => b.MigrationsAssembly("CryptoAvenue.Dal"))
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TradeOfferEntityTypeConfiguration());
        }
    }
}
