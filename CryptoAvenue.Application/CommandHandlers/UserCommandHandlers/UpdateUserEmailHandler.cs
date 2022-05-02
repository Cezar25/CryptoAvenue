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
    public class UpdateUserEmailHandler : IRequestHandler<UpdateUserEmail, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserEmailHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUserEmail request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);

            user.Email = request.UserEmail;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
