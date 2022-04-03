using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Domain.Documents;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using HotChocolate.Data;
using HotChocolate.Types;
using Application.Features.TodoLists.Queries.GetAll;
using Application.Features.TodoLists.Queries.GetById;
using Application.Constants;

namespace WebAPI.GraphQL.Queries
{
    [ExtendObjectType(Name = GraphQLRequestType.QUERY)]
    public class TodoListQuery
    {
        [UsePaging]
        [UseFiltering]
        public async Task<ICollection<TodoList>> GetTodoLists([Service] ISender sender)
        {
            return await sender.Send(new GetAllTodoListsQuery());
        }

        public async Task<TodoList> GetTodoList(string id, [Service] ISender sender)
        {
            return await sender.Send(new GetByIdTodoListQuery() { Id = id });
        }
    }
}
