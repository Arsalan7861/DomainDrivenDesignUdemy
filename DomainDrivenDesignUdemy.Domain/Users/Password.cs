namespace DomainDrivenDesignUdemy.Domain.Users
{
    public sealed record Password
    {
        public string Value { get; init; }
        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Password cannot be empty.");
            }
            if (value.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long.");
            }
            Value = value;
        }
    }
}
