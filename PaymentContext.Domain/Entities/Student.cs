using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;

        AddNotifications(name, document, email);
    }

    public Name Name { get; private set; } 
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();
    private readonly IList<Subscription> _subscriptions = [];

    public void AddSubscription(Subscription subscription)
    {
        foreach (var item in Subscriptions) item.Disable();

        _subscriptions.Add(subscription);
    }
}
