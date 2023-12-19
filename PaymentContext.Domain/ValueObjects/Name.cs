using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsLowerThan(3, FirstName.Length, nameof(FirstName), "O nome deve conter ao menos 3 caracteres")
            .IsGreaterThan(60, FirstName.Length, nameof(FirstName), "O nome deve conter até no máximo 60 caracteres")

            .Requires()
            .IsLowerThan(3, LastName.Length, nameof(LastName), "O sobrenome deve conter ao menos 3 caracteres")
            .IsGreaterThan(60, LastName.Length, nameof(LastName), "O sobrenome deve conter até no máximo 60 caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
