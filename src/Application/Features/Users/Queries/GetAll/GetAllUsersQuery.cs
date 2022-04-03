using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<ICollection<User>>
    { }

    class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ICollection<User>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
