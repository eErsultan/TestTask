using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<User>
    {
        public string Id { get; set; }
    }

    class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetByIdUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(request.Id);
        }
    }
}
