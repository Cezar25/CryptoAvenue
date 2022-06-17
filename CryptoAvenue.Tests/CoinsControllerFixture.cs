using AutoMapper;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CryptoAvenue.Application.Queries.CoinQueries;
using CryptoAvenue.Application.Commands.CoinCommands;

namespace CryptoAvenue.Tests
{
    [TestClass]
    public class CoinsControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllCoins_Query_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllCoins>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new CoinsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllCoins();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllCoins>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCoinIdByAbreviation_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCoinIdByAbreviation>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomAbreviation = "EUR";

            //Act
            var controller = new CoinsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetCoinIdByAbreviation(randomAbreviation);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCoinIdByAbreviation>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteCoin_command_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteCoin>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();

            //Act
            var controller = new CoinsController(_mockMapper.Object, _mockMediator.Object);
            await controller.DeleteCoin(randomUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteCoin>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
