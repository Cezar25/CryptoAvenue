using CryptoAvenue.Application.Queries.UserQueries;
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
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmail, User>
    {
        private readonly IUserRepository repository;

        public GetUserByEmailHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public Task<User> Handle(GetUserByEmail request, CancellationToken cancellationToken)
        {
            var user = repository.GetUserByEmail(request.UserEmail);
            return Task.FromResult(user);
        }
    }
}
