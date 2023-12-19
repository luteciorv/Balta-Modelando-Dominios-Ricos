using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;

    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("48470529005", Domain.Enums.EDocumentType.CPF);
        _email = new Email("batman@dc.com");
        _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham City", "SP", "BR", "13400000");

        _student = new Student(_name, _document, _email);

        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_tiver_assinatura_ativa()
    {
        var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne LTDA", _document, _address, _email);
        _subscription.AddPayment(payment);

        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_quando_adicionar_assinatura()
    {
        var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne LTDA", _document, _address, _email);
        _subscription.AddPayment(payment);

        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_inscricoes_nao_tiver_pagamento()
    {
        _student.AddSubscription(_subscription);

        Assert.IsFalse(_student.IsValid);
    }
}
