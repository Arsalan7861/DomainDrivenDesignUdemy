using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructur.Context.Repositories
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
        {
            Product product = new(
                Guid.CreateVersion7(),
                new(name),
                quantity,
                new(amount, Currency.FromCode(currency)),
                categoryId);
            await _context.Products.AddAsync(product);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
