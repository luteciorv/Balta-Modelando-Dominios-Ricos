using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void Deve_retornar_erro_quando_nome_estiver_invalido()
    {
        var command = new CreateBoletoSubscriptionCommand
        {
            FirstName = "",
            LastName = ""
        };

        command.Validate();

        Assert.IsFalse(command.IsValid);
    }
}
