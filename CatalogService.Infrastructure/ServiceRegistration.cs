using CatalogService.Application.Interfaces;
using CatalogService.Application.Mappings;
using CatalogService.Application.Services;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Infrastructure.Persistence.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CatalogService.Infrastructure
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //DBContext
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") ?? configuration.GetConnectionString("DbConnection");
            services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));

            //Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            //Services
            services.AddScoped<IProductAppService, ProductAppService>();

            //Mapster For Custom Mappings
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(CatalogRegister).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
