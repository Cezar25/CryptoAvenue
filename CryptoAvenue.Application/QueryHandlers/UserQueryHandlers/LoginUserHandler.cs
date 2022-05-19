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
    public class LoginUserHandler : IRequestHandler<LoginUser, LoginModel>
    {
        private readonly IUserRepository repository;

        public LoginUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<LoginModel> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityBy(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
                return null;

            var sentLoginModel = new LoginModel
            {
                Email = request.Email,
                Password = request.Password
            };

            return Task.FromResult(sentLoginModel);
        }

        //public Task<User> Handle(LoginUser request, CancellationToken cancellationToken)
        //{
        //    var user = repository.GetEntityBy(x => x.Email == request.Email && x.Password == request.Password);

        //    if (user == null)
        //        return null;

        //    return Task.FromResult(user);
        //}
    }
}
