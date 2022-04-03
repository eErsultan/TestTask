using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Commands.Delete
{
    public class DeleteTodoListCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; }
    }

    class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, Response<bool>>
    {
        private readonly ITodoListRepository _repository;

        public DeleteTodoListCommandHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(request.Id);

            return new Response<bool>(true);
        }
    }
}
