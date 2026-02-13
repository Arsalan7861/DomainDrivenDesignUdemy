namespace DomainDrivenDesignUdemy.Domain.Shared
{
    public sealed record Currency
    {
        internal static readonly Currency NONE = new("");
        public static readonly Currency USD = new("USD");
        public static readonly Currency TRY = new("TRY");
        public string Code { get; init; }

        private Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ?? throw new ArgumentException($"Invalid currency code: {code}");
        }

        public static readonly IReadOnlyCollection
            <Currency> All = new[] { USD, TRY };
    }
}
