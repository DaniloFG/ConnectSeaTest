using ConnectSeaRepository.Context;
using ConnectSeaRepository.Interface;
using ConnectSeaRepository.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectSeaRepository.Extension
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {            
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DB"));

            services.AddTransient<IManifestoRepository, ManifestoRepository>();

            return services;
        }
    }
}