using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using AutoMapper;
using Domain.Documents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Commands.Create
{
    public class CreateTodoListCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public ICollection<TodoItem> Items { get; set; }
    }

    class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Response<string>>
    {
        private readonly ITodoListRepository _repository;
        private readonly IMapper _mapper;

        public CreateTodoListCommandHandler(
            ITodoListRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = _mapper.Map<TodoList>(request);
            await _repository.InsertOneAsync(todoList);

            return new Response<string>(todoList.Id);
        }
    }
}
