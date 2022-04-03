using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Queries.GetById
{
    public class GetByIdTodoListQuery : IRequest<TodoList>
    {
        public string Id { get; set; }
    }

    class GetByIdTodoListQueryHandler : IRequestHandler<GetByIdTodoListQuery, TodoList>
    {
        private readonly ITodoListRepository _repository;

        public GetByIdTodoListQueryHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoList> Handle(GetByIdTodoListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(request.Id);
        }
    }
}
