using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Orders.Events
{
    public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            // Mail Gonder islemi
            return Task.CompletedTask;
        }
    }
}
