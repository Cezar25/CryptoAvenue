using AutoMapper;
using CryptoAvenue.Application.Commands.UserCommands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Application.Queries.UserQueries;
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
    public class UsersControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Users_query_is_called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAllUsers();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Update_User_Profile_Type_Command_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateUserProfileType>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.UpdateUserProfileType(randomUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateUserProfileType>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_User_By_Id_Query_Is_Called()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByID>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var randomUserId = Guid.NewGuid();

            //Act
            var controller = new UsersController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetUserById(randomUserId);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUserByID>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
