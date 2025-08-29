using ConnectSeaApplication.Interface;
using ConnectSeaApplication.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectSeaApplication.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IManifestoService, ManifestoService>();

            return services;
        }
    }
}