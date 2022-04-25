using CryptoAvenue.Application.Commands.UserCommands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers.UserCommandHandlers
{
    public class UpdateUserProfileTypeHandler : IRequestHandler<UpdateUserProfileType, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserProfileTypeHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUserProfileType request, CancellationToken cancellationToken)
        {
            var user = new User();

            user.Id = request.UserID;
            user.PrivateProfile = request.ProfileType;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
