namespace DomainDrivenDesignUdemy.Domain.Users
{
    public sealed record Email // Value Object, immutable, can only be set during object initialization, does not have an identity, we can control the creation of Email objects by validating the email format in the constructor, and if the email is not valid, we can throw an exception to prevent the creation of an invalid Email object.
    {
        public string Value { get; init; }
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email cannot be empty.");
            }
            if (!value.Contains("@"))
            {
                throw new ArgumentException("Email must contain '@' symbol.");
            }
            Value = value;
        }
    }
}
