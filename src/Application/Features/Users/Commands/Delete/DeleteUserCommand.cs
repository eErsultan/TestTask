using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; }
    }

    class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(request.Id);

            return new Response<bool>(true);
        }
    }
}
