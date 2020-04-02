using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Thomas.Business.Interfaces;
using Thomas.Business.Interfaces.Services;
using Thomas.Business.Notifications;
using Thomas.Business.Services;
using Thomas.Data.Context;
using Thomas.Data.Repository;

namespace Thomas.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IChamadoRepository, ChamadoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IChamadoService, ChamadoService>();
            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILogger>((context) =>
            {
                return Logger.Factory.Get();
            });

            return services;

        }
    }
}
