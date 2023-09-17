namespace Application.Services.Implementations.V1.AfterOrder;

using System.Threading.Tasks;
using Application.DTOs.Input.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;
using Domain.Repositories.Marketing;
using FluentValidation;
using Application.Validations;
using Application.DbTransaction;
using Domain.Entities.Marketing;
using FluentQueue.Interfaces.Bus;
using Application.Bus.Messages.RabbitMq;
using Application.Bus.Messages.Body;
using Application.Bus.Messages.Property;
using Application.Bus.Queues.RabbitMq;

public class AfterOrderAddServiceV1 : IAfterOrderAddServiceV1
{
    private readonly IValidator<AfterOrderAddDtoV1> _validator;
    private readonly IAfterOrderRulesRepository _afterOrderRulesRepository;
    private readonly IMarketingTransactionProvider _marketingTransaction;
    private readonly IBus _bus;

    public AfterOrderAddServiceV1(
        IValidator<AfterOrderAddDtoV1> validator,
        IAfterOrderRulesRepository afterOrderRulesRepository,
        IMarketingTransactionProvider marketingTransaction,
        IBus bus
    )
    {
        _validator = validator;
        _afterOrderRulesRepository = afterOrderRulesRepository;
        _marketingTransaction = marketingTransaction;
        _bus = bus;
    }
    public async Task Handle(AfterOrderAddDtoV1 dto)
    {
        await _validator.Validated(payload: dto);

        _bus.Message(
            message: new TestMessage(
                body: new TestMessageBody
                {
                    Key = "key",
                    Value = "value"
                },
                properties: new TestProperties
                {
                    CorrelationId = "test_correlation_id",
                    // Expiration = DateTime.Now.AddDays(1)
                }
            )
        ).OnQueue(
            queue: new TestQueue()
        ).OnConnection(
            connection: "LocalRabbit"
        ).OnDelay(
            availableAt: DateTime.Now.AddSeconds(5)
        ).Dispatch();

        /* var e = new AfterOrderRules{
            Name = "asd",
            Description = "asd",
            Enable = true,
            IgnoreVoucher = true
        };

        await _marketingTransaction.Transaction(async () => {
            await _afterOrderRulesRepository.AddAsync(entity: e);
            throw new Exception("kooooooriii");
        });

        throw new NotImplementedException(); */
    }
}
