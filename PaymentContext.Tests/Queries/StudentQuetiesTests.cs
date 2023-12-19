using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQuetiesTests
{
    private readonly IList<Student> _students;

    public StudentQuetiesTests()
    {
        _students = new List<Student>();

        for (int i = 0; i < 10; i++)
        {
            var name = new Name($"Aluno {i}", $"Sobrenom {i}");
            var document = new Document($"9999999999{i}", Domain.Enums.EDocumentType.CPF);
            var email = new Email($"teste_{i}@localhost.com");

            _students.Add(new(name, document, email));
        }
    }

    [TestMethod]
    public void Deve_retornar_null_quando_documento_nao_existir()
    {
        var query = StudentQueries.GetStudent("123456789");
        var student = _students.AsQueryable().Where(query).FirstOrDefault();

        Assert.IsNull(student);
    }

    [TestMethod]
    public void Deve_retornar_estudante_quando_documento_existir()
    {
        var query = StudentQueries.GetStudent("99999999999");
        var student = _students.AsQueryable().Where(query).FirstOrDefault();

        Assert.IsNotNull(student);
    }
}
