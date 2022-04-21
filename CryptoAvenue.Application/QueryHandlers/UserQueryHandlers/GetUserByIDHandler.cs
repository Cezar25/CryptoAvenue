using CryptoAvenue.Application.Queries.UserQueries;
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
    public class GetUserByIDHandler : IRequestHandler<GetUserByID, User>
    {
        private readonly CryptoAvenueContext context;

        public GetUserByIDHandler(CryptoAvenueContext context)
        {
            this.context = context;
        }

        public async Task<User> Handle(GetUserByID request, CancellationToken cancellationToken)
        {
            var user = context.Users.SingleOrDefault(x => x.UserID == request.UserID);
            return user;
        }
    }
}
