
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment(
    string barCode,
    string boletoNumber,
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    string owner,
    Document document,
    Address address,
    Email email
    ) : Payment(paidDate, expireDate, total, totalPaid, owner, document, address, email)
{
    public string BarCode { get; private set; } = barCode;
    public string BoletoNumber { get; private set; } = boletoNumber;
}
