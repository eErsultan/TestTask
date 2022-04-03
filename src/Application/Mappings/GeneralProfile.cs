using Application.Features.TodoLists.Commands.Create;
using Application.Features.TodoLists.Commands.Update;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Update;
using AutoMapper;
using Domain.Documents;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            CreateMap<CreateTodoListCommand, TodoList>();
            CreateMap<UpdateTodoListCommand, TodoList>();
        }
    }
}