using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Users.Events
{
    public sealed class UserDomainEvent : INotification
    {
        public User User { get; set; }

        public UserDomainEvent(User user)
        {
            User = user;
        }
    }
}
