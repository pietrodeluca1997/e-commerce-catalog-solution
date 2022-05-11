using Catalog.Application.Contracts.Services;
using Catalog.Application.Services.Products;
using Catalog.Domain.Contracts.Commands;
using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Contracts.Mediator;
using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Mediator;
using Catalog.Domain.Modules.Products.Commands.CreateNewProduct;
using Catalog.Domain.Modules.Products.Events;
using Catalog.Infrastructure.Contracts;
using Catalog.Infrastructure.Events;
using Catalog.Infrastructure.Persistance;
using Catalog.Infrastructure.Persistance.DAO;
using Catalog.Infrastructure.Queue;
using Catalog.Infrastructure.Settings;

namespace Catalog.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void InjectApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductServices>();
        }
        public static void InjectPersistance(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncBaseRepository<>), typeof(MongoBaseRepository<>));
            services.AddScoped<ISqlServerManager, SqlServerManager>();
            services.AddScoped<IProductDAO, ProductDAO>();
        }
        public static void InjectSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(SqlServerSettings), options => configuration.GetSection("SqlServerSettings").Get<SqlServerSettings>());
            services.AddScoped(typeof(MongoSettings), options => configuration.GetSection("MongoSettings").Get<MongoSettings>());

        }
        public static void InjectCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommandMediator, CommandMediator>();
            services.AddScoped<ICommandHandler<CreateNewProductCommand, CreateNewProductCommandResponse>, CreateNewProductHandler>();
        }
        public static void InjectEvents(this IServiceCollection services)
        {            
            services.AddScoped<IEventMediator, EventMediator>();
            services.AddScoped<IEventHandler<ProductCreatedEvent>, SyncProduct>();
            services.AddScoped<IEventHandler<ProductCreatedEvent>, ReportQueue>();
        }
    }
}
