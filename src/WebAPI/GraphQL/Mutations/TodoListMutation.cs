using Application.Constants;
using Application.DTOs.Common;
using Application.Features.TodoLists.Commands.Create;
using Application.Features.TodoLists.Commands.Delete;
using Application.Features.TodoLists.Commands.Update;
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
    public class TodoListMutation
    {
        public async Task<Response<string>> CreateTodoList(
            CreateTodoListCommand input,
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }

        public async Task<Response<bool>> DeleteTodoList(
            DeleteTodoListCommand input,
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }

        public async Task<Response<TodoList>> UpdateTodoList(
            UpdateTodoListCommand input,
            [Service] ISender sender)
        {
            return await sender.Send(input);
        }
    }
}
