using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string BarCode { get; set; } = string.Empty;
    public string BoletoNumber { get; set; } = string.Empty;

    public string PaymentNumber { get; set; } = string.Empty;
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; } = string.Empty;

    public string PayerDocument { get; set; } = string.Empty;
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
            .Requires()
            .IsLowerThan(3, FirstName.Length, nameof(FirstName), "O nome deve conter ao menos 3 caracteres")
            .IsGreaterThan(60, FirstName.Length, nameof(FirstName), "O nome deve conter até no máximo 60 caracteres")

            .Requires()
            .IsLowerThan(3, LastName.Length, nameof(LastName), "O sobrenome deve conter ao menos 3 caracteres")
            .IsGreaterThan(60, LastName.Length, nameof(LastName), "O sobrenome deve conter até no máximo 60 caracteres")
        );
    }
}
