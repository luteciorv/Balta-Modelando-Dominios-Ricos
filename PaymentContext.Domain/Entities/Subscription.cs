namespace PaymentContext.Domain.Entities;

public class Subscription
{
    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        Active = true;
        ExpireDate = expireDate;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }

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
