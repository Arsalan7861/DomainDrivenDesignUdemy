using System.Reflection;
using DomainDrivenDesignUdemy.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesignUdemy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(Entity).Assembly // for the domain events handlers
                ));
            return services;
        }
    }
}
