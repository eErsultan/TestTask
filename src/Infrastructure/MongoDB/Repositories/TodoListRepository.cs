using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using Domain.Settings;
using Infrastructure.MongoDB.Repositories.Base;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.Repositories
{
    public class TodoListRepository : MongoRepository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(IMongoClient client, IOptions<MongoDBSettings> settings) : base(client, settings.Value)
        { }
    }
}
