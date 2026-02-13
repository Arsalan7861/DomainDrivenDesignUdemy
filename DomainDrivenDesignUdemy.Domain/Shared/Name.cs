namespace DomainDrivenDesignUdemy.Domain.Shared
{
    public sealed record Name
    {
        public string Value { get; init; }
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Name must be at least 3 characters long.");
            }
            Value = value;
        }
    }
}
