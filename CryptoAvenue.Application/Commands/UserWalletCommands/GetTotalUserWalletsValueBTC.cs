using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Commands.UserWalletCommands
{
    public class GetTotalUserWalletsValueBTC : IRequest<double>
    {
        public Guid UserId { get; set; }
    }
}
