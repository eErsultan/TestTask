using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Domain.Documents;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using HotChocolate.Data;
using HotChocolate.Types;
using Application.Constants;

namespace WebAPI.GraphQL.Queries
{
    [ExtendObjectType(Name = GraphQLRequestType.QUERY)]
    public class UserQuery
    {
        [UsePaging]
        [UseFiltering]
        public async Task<ICollection<User>> GetUsers([Service] ISender sender)
        {
            return await sender.Send(new GetAllUsersQuery());
        }

        public async Task<User> GetUser(string id, [Service] ISender sender)
        {
            return await sender.Send(new GetByIdUserQuery() { Id = id });
        }
    }
}
