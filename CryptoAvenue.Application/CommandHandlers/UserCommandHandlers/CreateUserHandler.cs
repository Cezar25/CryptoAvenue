﻿using CryptoAvenue.Application.Commands;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Application.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository repository;

        public CreateUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Email = request.Email,
                Password = request.Password,
                Age = request.Age,
                SecurityQuestion = request.SecurityQuestion,
                SecurityAnswer = request.SecurityAnswer
            };
            if (user == null) return null;

            repository.Insert(user);
            repository.SaveChanges();

            return user;
        }
    }
}