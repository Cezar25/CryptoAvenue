using AutoMapper;
using CryptoAvenue.Application.Commands.TradeOfferCommands;
using CryptoAvenue.Application.Queries.TradeOfferQueries;
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
    public class TradeOffersControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Trade_Offers_By_Recipient_Id_Query_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTradeOffersByRecipientID>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();

            //Act
            var controller = new TradeOffersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetTradeOfferByRecipientId(randomUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetTradeOffersByRecipientID>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Apply_Trade_Offer_To_Users_Command_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<ApplyTradeOfferToUsers>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomOfferId = Guid.NewGuid();

            //Act
            var controller = new TradeOffersController(_mockMapper.Object, _mockMediator.Object);
            await controller.AcceptTradeOffer(randomOfferId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<ApplyTradeOfferToUsers>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Trade_Offer_Details_Query_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetTradeOfferDetails>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomOfferId = Guid.NewGuid();

            //Act
            var controller = new TradeOffersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetTradeOfferDetails(randomOfferId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetTradeOfferDetails>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
