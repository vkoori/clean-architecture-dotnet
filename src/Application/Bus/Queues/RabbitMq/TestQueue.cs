namespace Application.Bus.Queues.RabbitMq;

public class TestQueue : RabbitMqQueueBase
{
    public override string QueueName { get; set; } = "test-queue";
}
