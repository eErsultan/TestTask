using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Queries.GetAll
{
    public class GetAllTodoListsQuery : IRequest<ICollection<TodoList>>
    { }

    class GetAllTodoListsQueryHandler : IRequestHandler<GetAllTodoListsQuery, ICollection<TodoList>>
    {
        private readonly ITodoListRepository _repository;

        public GetAllTodoListsQueryHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<TodoList>> Handle(GetAllTodoListsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
