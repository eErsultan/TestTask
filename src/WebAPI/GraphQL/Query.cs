using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;

namespace WebAPI.GraphQL
{
    public class Query
    {
        private readonly IUserRepository _userRepository;

        public Query(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _userRepository.GetPagedResponseAsync(1, 10);
        }
    }
}
