﻿
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment(
    string transactionCode,
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
    public string TransactionCode { get; private set; } = transactionCode;
}
