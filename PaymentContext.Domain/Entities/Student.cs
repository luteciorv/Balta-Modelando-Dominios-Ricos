using Flunt.Validations;
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
        var hasSubscriptionActive = Subscriptions.Any(s => s.Active);

        AddNotifications(new Contract<Student>()
            .Requires()
            .AreNotEquals(0, subscription.Payments.Count, nameof(subscription.Payments), "Esta assinatura não possui nenhum pagamento associado")
            .IsFalse(hasSubscriptionActive, nameof(Subscriptions), "O aluno já possui alguma assinatura ativa")
        );

        _subscriptions.Add(subscription);
    }
}
