using Application.Interfaces.Repositories.MongoDB;
using Domain.Documents;
using Domain.Settings;
using Infrastructure.MongoDB.Repositories.Base;
using Microsoft.Extensions.Options;

namespace Infrastructure.MongoDB.Repositories
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoDBSettings> settings) : base(settings.Value)
        { }
    }
}
