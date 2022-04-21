using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
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
        private readonly CryptoAvenueContext context;

        public GetAllUsersHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return context.Users.ToList();
        }
    }
}
