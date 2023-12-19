using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        if (string.IsNullOrWhiteSpace(FirstName)) 
            AddNotification(nameof(FirstName), "Nome inválido");

        if (string.IsNullOrWhiteSpace(LastName)) 
            AddNotification(nameof(LastName), "Sobrenome inválido");
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
