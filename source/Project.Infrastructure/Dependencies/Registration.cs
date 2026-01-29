using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Project.Infrastructure.Dependencies
{
    /// <summary>
    /// Static registration for the application
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// Registers all application dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<ApplicationContext>(configuration.GetConnectionString("Database"));
            services.AddScoped(_ => new MongoClient(configuration.GetConnectionString("Mongo")));

            BsonSerializer.TryRegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        }
    }
}