using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.GraphQL
{
    public class Mutation
    {
        private readonly IUserRepository _userRepository;

        public Mutation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserPayload> AddUser(CreateUserInput input)
        {
            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Patronymic = input.Patronymic,
                Age = input.Age,
                NumberPhone = input.NumberPhone,
                Email = input.Email
            };

            await _userRepository.InsertOneAsync(user);

            return new CreateUserPayload() { Id = user.Id };
        }

        public async Task<DeleteUserPayload> DeleteUser(DeleteUserInput input)
        {
            await _userRepository.DeleteByIdAsync(input.Id);

            return new DeleteUserPayload() { Id = input.Id };
        }

        public async Task<Application.Features.Users.Commands.Update.UpdateUserPayload> UpdateUser(
            Application.Features.Users.Commands.Update.UpdateUserInput input)
        {
            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Patronymic = input.Patronymic,
                Age = input.Age,
                NumberPhone = input.NumberPhone,
                Email = input.Email,
                Id = input.Id
            };

            await _userRepository.ReplaceOneAsync(user);

            return new Application.Features.Users.Commands.Update.UpdateUserPayload() {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Age = user.Age,
                NumberPhone = user.NumberPhone,
                Email = user.Email,
                Id = user.Id
            };
        }
    }
}
