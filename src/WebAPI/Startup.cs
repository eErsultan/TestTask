using Application;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.GraphQL;
using Application.Interfaces.Repositories;
using Infrastructure.MongoDB;
using WebAPI.GraphQL.Queries;
using WebAPI.GraphQL.Mutations;
using Application.Constants;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer(Configuration);
            services.AddMongoDBInfrastructure(Configuration);
            services.AddGraphQLServer()
                    .AddFiltering()
                    .ModifyRequestOptions(o => o.IncludeExceptionDetails = true)
                    .AddQueryType(q => q.Name(GraphQLRequestType.QUERY))
                        .AddType<UserQuery>()
                        .AddType<TodoListQuery>()
                    .AddMutationType(m => m.Name(GraphQLRequestType.MUTATION))
                        .AddType<UserMutation>()
                        .AddType<TodoListMutation>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
