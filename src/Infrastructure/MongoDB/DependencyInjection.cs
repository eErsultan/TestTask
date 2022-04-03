using Application.Interfaces.Repositories.Base;
using Application.Interfaces.Repositories.MongoDB;
using Domain.Settings;
using Infrastructure.MongoDB.Repositories;
using Infrastructure.MongoDB.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.MongoDB
{
    public static class DependencyInjection
    {
        public static void AddMongoDBInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));
            services.AddSingleton<IMongoClient>(c => 
                new MongoClient(configuration["MongoDBSettings:ConnectionURI"]));

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoListRepository, TodoListRepository>();
        }
    }
}
