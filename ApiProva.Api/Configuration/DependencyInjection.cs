using ApiProva.Service.Service.Interface;
using ApiProva.Service.Service;
using Microsoft.EntityFrameworkCore;
using ApiProva.Data.Data;
using ApiProva.Data.Repository;
using ApiProva.Data.Repository.Interface;

namespace ApiProva.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiProvaDbContext>(options =>
                                                options.UseSqlServer(configuration
                                                    .GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IContatoRepository, ContatoRepository>();
            return repositories;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContatoService, ContatoService>();
            return services;
        }
    }
}
