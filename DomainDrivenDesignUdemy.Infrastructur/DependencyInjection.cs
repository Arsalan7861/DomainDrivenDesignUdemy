using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Categories;
using DomainDrivenDesignUdemy.Domain.Orders;
using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Users;
using DomainDrivenDesignUdemy.Infrastructur.Context;
using DomainDrivenDesignUdemy.Infrastructur.Context.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesignUdemy.Infrastructur
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addinfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>()); // IUnitOfWork arayüzü, ApplicationDbContext tarafından uygulanır, bu nedenle IUnitOfWork talep edildiğinde ApplicationDbContext örneği sağlanır.
            services.AddScoped<IUserRepository, UserRepository>(); // IUserRepository arayüzü, UserRepository sınıfı tarafından uygulanır, bu nedenle IUserRepository talep edildiğinde UserRepository örneği sağlanır.
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
