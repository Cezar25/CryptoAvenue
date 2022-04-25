using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Application.IndependentBLL;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserWalletCommandHandlers
{
    public class AddCopiedPortofolioToUserHandler : IRequestHandler<AddCopiedPortofolioToUser>
    {
        private readonly IWalletRepository walletRepository;
        private readonly IUserRepository userRepository;

        public AddCopiedPortofolioToUserHandler(IWalletRepository walletRepository, IUserRepository userRepository)
        {
            this.walletRepository = walletRepository;
            this.userRepository = userRepository;
        }

        public Task<Unit> Handle(AddCopiedPortofolioToUser request, CancellationToken cancellationToken)
        {
            var bll = new BLL(walletRepository);

            var user = userRepository.GetEntityByID(request.CopiedId);

            var coinPercentage = bll.GetCoinPercentage(user);

            foreach (var pair in coinPercentage)
            {
                if (walletRepository.GetAll().Any(x => x.UserID == request.CopierId && x.CoinType.Abreviation == pair.Key.Abreviation))
                {
                    var foundWallet = walletRepository.GetAll().FirstOrDefault(x => x.UserID == request.CopierId && x.CoinType.Abreviation == pair.Key.Abreviation);

                    double addedAmount = ((pair.Value / 100) * request.Amount) / foundWallet.CoinType.ValueInEUR;
                    foundWallet.CoinAmount += addedAmount;

                    walletRepository.Update(foundWallet);
                }
                else
                {
                    double addedAmount = ((pair.Value / 100) * request.Amount) / pair.Key.ValueInEUR;
                    walletRepository.Insert(new Wallet() { CoinID = pair.Key.Id, UserID = request.CopierId, CoinAmount = addedAmount });
                }

                walletRepository.SaveChanges();
            }

            return (Task<Unit>)Task.CompletedTask;
        }
    }
}
