using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class CreateBoletoSubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService) : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IEmailService _emailService = emailService;

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar a assinatura");
        }

        if (_studentRepository.DocumentExists(command.Document))
            AddNotification(nameof(command.Document), "Este CPF já está em uso");

        if (_studentRepository.EmailExists(command.Email))
            AddNotification(nameof(command.Email), "Este E-mail já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));

        var payerDocument = new Document(command.PayerDocument, command.PayerDocumentType);
        var payerEmail = new Email(command.PayerEmail);
        var payment = new BoletoPayment(
            command.BarCode, 
            command.BoletoNumber, 
            command.PaidDate, 
            command.ExpireDate, 
            command.Total, 
            command.Total, 
            command.Payer, 
            payerDocument, 
            address, 
            payerEmail);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address);
        AddNotifications(payerDocument, payerEmail);
        AddNotifications(student, subscription, payment);

        if (!IsValid) return new CommandResult(false, "Não foi possível realizar a assinatura");

        _studentRepository.CreateSubscription(student);

        _emailService.Send(student.Name.FirstName, student.Email.Address, "Bem vindo ao Balta.io", "Sua assinatura foi criada com sucesso!");

        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}
