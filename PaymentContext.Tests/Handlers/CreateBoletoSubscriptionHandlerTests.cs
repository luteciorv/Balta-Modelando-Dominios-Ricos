using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class CreateBoletoSubscriptionHandlerTests
{
    private readonly FakeStudentRepository _studentRepository;
    private readonly FakeEmailService _emailService;
    
    public CreateBoletoSubscriptionHandlerTests()
    {
        _studentRepository = new();
        _emailService = new();
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_documento_ja_estiver_cadastrado()
    {
        var handler = new CreateBoletoSubscriptionHandler(_studentRepository, _emailService);

        var command = new CreateBoletoSubscriptionCommand
        {
            FirstName = "Bruce",
            LastName = "Wayne",
            Document = "99999999999",
            Email = "hello@balta.io2",
            BarCode = "123456789",
            BoletoNumber = "1234654987",
            PaymentNumber = "123121",
            PaidDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddMonths(1),
            Total = 60,
            TotalPaid = 60,
            Payer = "WAYNE CORP",
            PayerDocument = "12345678911",
            PayerDocumentType = EDocumentType.CPF,
            PayerEmail = "batman@dc.com",
            Street = "Rua 123",
            Number = "asdd",
            Neighborhood = "asdasd",
            City = "as",
            State = "as",
            Country = "as",
            ZipCode = "12345678"
        };

        handler.Handle(command);

        Assert.IsFalse(handler.IsValid);
    }
}
