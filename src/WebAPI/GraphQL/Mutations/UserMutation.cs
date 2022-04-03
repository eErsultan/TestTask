using Application.Constants;
using Application.DTOs.Common;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.GraphQL.Mutations
{
    [ExtendObjectType(Name = GraphQLRequestType.MUTATION)]
    public class UserMutation
    {
        public async Task<Response<string>> CreateUser(
            CreateUserCommand input, 
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }

        public async Task<Response<bool>> DeleteUser(
            DeleteUserCommand input,
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }

        public async Task<Response<User>> UpdateUser(
            UpdateUserCommand input,
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }
    }
}
