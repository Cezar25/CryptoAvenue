using CryptoAvenue.Application.Commands;
using CryptoAvenue.Domain.IRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        private readonly IUserRepository repository;

        public CreateUserValidator(IUserRepository repository)
        {
            this.repository = repository;

            RuleFor(x => x).MustAsync(IsEmailAlreadyUsed).WithMessage("Email already in use!");
        }

        public async Task<bool> IsEmailAlreadyUsed(CreateUser user, CancellationToken cancellationToken)
        {
            return repository.Any(x => x.Email == user.Email);
        }
    }
}
