using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email(string address) : ValueObject
{
    public string Address { get; private set; } = address;
}
