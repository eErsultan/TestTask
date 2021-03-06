using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using Domain.Settings;
using Infrastructure.MongoDB.Repositories.Base;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.Repositories
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IMongoClient client, IOptions<MongoDBSettings> settings) : base(client, settings.Value)
        { }
    }
}
