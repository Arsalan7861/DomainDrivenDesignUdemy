using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Users.Events
{
    public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            // Mail Gonder islemi
            return Task.CompletedTask;
        }
    }
}
