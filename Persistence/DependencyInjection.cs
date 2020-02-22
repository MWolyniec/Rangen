using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rangen.Application.Common.Interfaces;

namespace Rangen.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RangenDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RangenDatabase")));

            services.AddScoped<IRangenDbContext>(provider => provider.GetService<RangenDbContext>());

            return services;
        }
    }
}
