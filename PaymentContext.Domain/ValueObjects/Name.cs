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
            .IsLowerThan(FirstName.Length, 3, nameof(FirstName), "O nome deve conter ao menos 3 caracteres")
            .IsGreaterThan(FirstName.Length, 60, nameof(FirstName), "O nome deve conter até no máximo 60 caracteres")

            .Requires()
            .IsLowerThan(LastName.Length, 3, nameof(LastName), "O sobrenome deve conter ao menos 3 caracteres")
            .IsGreaterThan(LastName.Length, 60, nameof(LastName), "O sobrenome deve conter até no máximo 60 caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
