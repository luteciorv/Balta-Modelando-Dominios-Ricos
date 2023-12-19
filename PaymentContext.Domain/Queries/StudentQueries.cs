using PaymentContext.Domain.Entities;
using System.Linq.Expressions;

namespace PaymentContext.Domain.Queries;

public static class StudentQueries
{
    public static Expression<Func<Student, bool>> GetStudent(string document) =>
        s => s.Document.Number == document;
}
