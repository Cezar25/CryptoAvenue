using CryptoAvenue.Application.Queries.UserQueries;
using CryptoAvenue.Dal;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.UserQueryHandlers
{
    public class GetUserByIDHandler : IRequestHandler<GetUserByID, User>
    {
        private readonly IUserRepository repository;

        public GetUserByIDHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(GetUserByID request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);
            return Task.FromResult(user);
        }
    }
}
