namespace Application.Bus.Messages.RabbitMq.Exchange;

using FluentQueue.Interfaces.Drivers.RabbitMQ.Message;

public class TestExchange : IExchange
{
    public string Name { get; set; } = "test";
    public string Type { get; set; } = "x-delayed-message";
    public bool Durable { get; set; } = true;
    public bool AutoDelete { get; set; } = false;
    public IDictionary<string, object>? Arguments { get; set; } = new Dictionary<string, object>{{"x-delayed-type", "direct" }};
}
