using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Categories;
using DomainDrivenDesignUdemy.Domain.Orders;
using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Shared;
using DomainDrivenDesignUdemy.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructur.Context
{
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ARSALANKHROUSH;Initial Catalog=DDDUdemyDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User sinifi icin alanlarin tanimi
            modelBuilder.Entity<User>()
                .Property(p => p.Name).HasConversion(name => name.Value, value => new(value)); // Value Object Name için dönüşüm ekleniyor, böylece Name sınıfının Value özelliği veritabanında saklanır ve geri okunurken Name nesnesi oluşturulur.
            modelBuilder.Entity<User>()
               .Property(p => p.Email).HasConversion(email => email.Value, value => new(value));
            modelBuilder.Entity<User>()
               .Property(p => p.Password).HasConversion(pass => pass.Value, value => new(value));
            modelBuilder.Entity<User>()
               .OwnsOne(p => p.Address); // Address sınıfı User tarafından sahiplenildiği için OwnsOne kullanılır, böylece Address nesnesi User ile birlikte saklanır ve yönetilir.

            // Category sinifi icin alanlarin tanimi
            modelBuilder.Entity<Category>()
               .Property(p => p.Name).HasConversion(name => name.Value, value => new(value));

            // Product sinifi icin alanlarin tanimi
            modelBuilder.Entity<Product>()
               .Property(p => p.Name).HasConversion(name => name.Value, value => new(value));
            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {// Price Money sinifindan oldugundan, Monet icinde Currency ve Amount alanlari var, bu nedenle bu alanlar için dönüşüm eklenir.
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p => p.Amount)
                    .HasColumnType("money"); // sql de farkli decimal turleri var, money da decimal turlerinden biridir, para birimi ve miktar için uygun bir türdür.
                });

            // Order sinifi icin alanlarin tanimi
            modelBuilder.Entity<OrderLine>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {// Price Money sinifindan oldugundan, Monet icinde Currency ve Amount alanlari var, bu nedenle bu alanlar için dönüşüm eklenir.
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p => p.Amount)
                    .HasColumnType("money"); // sql de farkli decimal turleri var, money da decimal turlerinden biridir, para birimi ve miktar için uygun bir türdür.
                });
        }
    }
}
