using AutoMapper;
using CryptoAvenue.Application.Commands.UserWalletCommands;
using CryptoAvenue.Application.Queries.WalletQueries;
using CryptoAvenue.Controllers;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoAvenue.Tests
{
    [TestClass]
    public class WalletsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Wallets_By_User_Id_Query_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetWalletsByUserID>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();

            //Act
            var controller = new WalletsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetWalletsByUserId(randomUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetWalletsByUserID>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Deposit_To_User_Account_Command_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DepositToUserAccount>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();
            var randomCoinId = Guid.NewGuid();
            var randomAmount = 12;

            //Act
            var controller = new WalletsController(_mockMapper.Object, _mockMediator.Object);
            await controller.DepositToUserAccount(randomUserId, randomCoinId, randomAmount);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DepositToUserAccount>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Delete_Wallet_Command_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteWallet>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomWalletId = Guid.NewGuid();

            //Act
            var controller = new WalletsController(_mockMapper.Object, _mockMediator.Object);
            await controller.DeleteWallet(randomWalletId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteWallet>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
