using DomainDrivenDesignUdemy.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructur.Context.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {
            Order order = new(
                Guid.CreateVersion7(),
                "1",
                DateTime.Now,
                OrderStatusEnum.AwaitingtApproval
                );
            order.CreateOrder(createOrderDtos);
            await _context.Orders.AddAsync(order, cancellationToken);
            return order;
        }

        public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Orders
                .Include(p => p.OrderLines)
                .ThenInclude(p => p.Product)
                .ToListAsync(cancellationToken);
        }
    }
}
