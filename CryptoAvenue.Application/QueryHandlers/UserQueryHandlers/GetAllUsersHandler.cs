using CryptoAvenue.Application.Queries;
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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<User>>
    {
        private readonly IUserRepository repository;

        public GetAllUsersHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
