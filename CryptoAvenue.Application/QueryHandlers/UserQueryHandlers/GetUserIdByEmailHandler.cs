using CryptoAvenue.Application.Queries.UserQueries;
using CryptoAvenue.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.QueryHandlers.UserQueryHandlers
{
    public class GetUserIdByEmailHandler : IRequestHandler<GetUserIdByEmail, Guid>
    {
        private readonly IUserRepository repository;

        public GetUserIdByEmailHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(GetUserIdByEmail request, CancellationToken cancellationToken)
        {
            var id = repository.GetEntityBy(x => x.Email == request.UserEmail).Id;

            return Task.FromResult(id);
        }
    }
}
