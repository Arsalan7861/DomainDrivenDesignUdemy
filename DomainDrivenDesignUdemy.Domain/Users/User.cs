using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Shared;

namespace DomainDrivenDesignUdemy.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Address Address { get; private set; }

        // factory method to create a new user -> Creation. Factory : creation of entity is not done by constructor but by a static method that can have more parameters and can have some logic to create the entity.
        public static User CreateUser(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress)
        {
            User user = new(
                id: Guid.CreateVersion7(),
                name: new(name),
                email: new(email),
                password: new(password),
                 new(country, city, street, postalCode, fullAddress)
                );

            return user;
        }

        // Methods to change user information -> Behavior
        public void ChangeName(string name)
        {
            Name = new(name);
        }
        public void ChangeAddress(string country, string city, string street, string postalCode, string fullAddress)
        {
            Address = new(country, city, street, postalCode, fullAddress);
        }
        public void ChangePassword(string password)
        {
            Password = new(password);
        }
        public void ChangeEmail(string email)
        {
            Email = new(email);
        }
    }
}
