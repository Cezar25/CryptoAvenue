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
    public class UpdateUserQnAHandler : IRequestHandler<UpdateUserQnA, User>
    {
        private readonly IUserRepository repository;
        public UpdateUserQnAHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public Task<User> Handle(UpdateUserQnA request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);
            user.Id = request.UserId;
            user.SecurityQuestion = request.UserSecurityQuestion;
            user.SecurityAnswer = request.UserSecurityAnswer;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
