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
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.UserId);
            updated.Id = request.UserId;
            updated.Email = request.Email;
            updated.Password = request.Password;
            updated.SecurityQuestion = request.SecurityQuestion;
            updated.SecurityAnswer = request.SecurityAnswer;
            updated.PrivateProfile = request.PrivateProfile;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
