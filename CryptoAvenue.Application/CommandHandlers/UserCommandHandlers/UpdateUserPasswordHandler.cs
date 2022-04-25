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
    public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPassword, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserPasswordHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUserPassword request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Id = request.UserId;
            user.Password = request.UserPassword;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
