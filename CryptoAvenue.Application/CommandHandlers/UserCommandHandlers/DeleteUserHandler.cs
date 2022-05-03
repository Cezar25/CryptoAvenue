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
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly IUserRepository repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityBy(x => x.Id == request.UserId);

            if (user == null) return null;

            repository.Delete(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
