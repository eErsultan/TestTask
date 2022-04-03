using Application.Interfaces.Repositories.Base;
using Domain.Documents;

namespace Application.Interfaces.Repositories.MongoDB
{
    public interface ITodoListRepository : IMongoRepository<TodoList>
    {
    }
}
