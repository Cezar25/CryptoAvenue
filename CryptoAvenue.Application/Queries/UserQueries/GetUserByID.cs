using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Queries.UserQueries
{
    public class GetUserByID : IRequest<User>
    {
        public Guid UserID { get; set; }
    }
}
