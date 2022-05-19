using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.UserQueries
{
    public class GetUserIdByEmail : IRequest<Guid>
    {
        public string UserEmail { get; set; }
    }
}
