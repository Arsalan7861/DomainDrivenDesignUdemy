using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Shared;

namespace DomainDrivenDesignUdemy.Domain.Orders
{
    public sealed class Order : Entity
    {
        public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedDate = createdDate;
            Status = status;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        // with these methods we can control the OrderLine class with Order class. The Order Class become Aggregate Root and OrderLine become Entity. We can not create OrderLine without Order class. We can not access OrderLine class directly. We can only access OrderLine class through Order class. This is the main principle of DDD. Aggregate Root is the main class that controls the other classes in the aggregate. The other classes in the aggregate are called Entities. The Aggregate Root is responsible for the consistency of the aggregate. The Aggregate Root is responsible for the business rules of the aggregate. The Aggregate Root is responsible for the invariants of the aggregate. The Aggregate Root is responsible for the lifecycle of the aggregate. The Aggregate Root is responsible for the persistence of the aggregate.
        public void CreateOrder(List<CreateOrderDto> createOrderDtos)
        {
            foreach (var item in createOrderDtos)
            {
                if (item.Quantity < 1)
                {
                    throw new ArgumentException("Order amount can not be less than 1");
                }

                // Other business rules can be added here

                OrderLine orderLine = new(
                    Guid.NewGuid(),
                    Id,
                    item.ProductId,
                    item.Quantity,
                    new(item.Amount, Currency.FromCode(item.Currency)));

                OrderLines.Add(orderLine);
            }
        }

        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderLine = OrderLines.FirstOrDefault(x => x.Id == orderLineId);
            if (orderLine is null)
            {
                throw new ArgumentException("Order line not found");
            }

            OrderLines.Remove(orderLine);
        }
    }
}
