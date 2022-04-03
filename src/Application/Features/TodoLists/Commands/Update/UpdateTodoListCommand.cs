using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using AutoMapper;
using Domain.Documents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Commands.Update
{
    public class UpdateTodoListCommand : IRequest<Response<TodoList>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoItem> Items { get; set; }
    }

    class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand, Response<TodoList>>
    {
        private readonly ITodoListRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTodoListCommandHandler(
            ITodoListRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<TodoList>> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = _mapper.Map<TodoList>(request);
            await _repository.ReplaceOneAsync(todoList);

            return new Response<TodoList>(todoList);
        }
    }
}
