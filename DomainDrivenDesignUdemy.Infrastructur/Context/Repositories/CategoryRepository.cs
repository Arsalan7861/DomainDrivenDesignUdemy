using DomainDrivenDesignUdemy.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructur.Context.Repositories
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            Category category = new(Guid.CreateVersion7(), new(name));
            await _context.Categories.AddAsync(category, cancellationToken);
        }

        public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
