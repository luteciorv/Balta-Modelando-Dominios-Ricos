using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmailOrEmpty(Address, nameof(Address), "Endereço de e-mail inválido")   
        );
    }
 
    public string Address { get; private set; }
}
