using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using AutoMapper;
using Domain.Documents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<string>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUserRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _repository.InsertOneAsync(user);

            return new Response<string>(user.Id);
        }
    }
}
