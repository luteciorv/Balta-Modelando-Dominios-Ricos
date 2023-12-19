using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void Deve_retornar_erro_quando_cnpj_invalido()
    {
        var document = new Document("123", Domain.Enums.EDocumentType.CNPJ);
        Assert.IsFalse(document.IsValid);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_quando_cnpj_valido()
    {
        var document = new Document("96840857000199", Domain.Enums.EDocumentType.CNPJ);
        Assert.IsTrue(document.IsValid);
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_cpf_invalido()
    {
        var document = new Document("123", Domain.Enums.EDocumentType.CPF);
        Assert.IsFalse(document.IsValid);
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_cpf_valido()
    {
        var document = new Document("37802735009", Domain.Enums.EDocumentType.CPF);
        Assert.IsTrue(document.IsValid);
    }
}
