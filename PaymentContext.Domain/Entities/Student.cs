namespace PaymentContext.Domain.Entities;

public class Student
{
    public Student(string firstName, string lastName, string document, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();
    private readonly IList<Subscription> _subscriptions = [];

    public void AddSubscription(Subscription subscription)
    {
        foreach (var item in Subscriptions) item.Disable();

        _subscriptions.Add(subscription);
    }
}
