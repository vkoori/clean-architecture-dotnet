namespace Application.Bus.Messages.RabbitMq.Exchange;

using FluentQueue.Interfaces.Drivers.RabbitMQ.Message;

public class TestExchange : IExchange
{
    public string Name { get; set; } = "test";
    public string Type { get; set; } = "direct";
}
