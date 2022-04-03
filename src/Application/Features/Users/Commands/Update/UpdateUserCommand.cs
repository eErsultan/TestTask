using Application.DTOs.Common;
using Application.Interfaces.Repositories.MongoDB;
using AutoMapper;
using Domain.Documents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<Response<User>>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<User>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IUserRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _repository.ReplaceOneAsync(user);

            return new Response<User>(user);
        }
    }
}
