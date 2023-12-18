namespace PaymentContext.Domain.Entities;

public class Subscription(DateTime? expireDate)
{
    public DateTime CreateDate { get; private set; } = DateTime.Now;
    public DateTime LastUpdateDate { get; private set; } = DateTime.Now;
    public DateTime? ExpireDate { get; private set; } = expireDate;
    public bool Active { get; private set; } = true;

    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();
    private readonly IList<Payment> _payments = [];

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }

    public void Disable()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}
