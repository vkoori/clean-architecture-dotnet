namespace Application.Bus.Messages.RabbitMq;

using Application.Bus.Messages.RabbitMq.Exchange;
using FluentQueue.Interfaces.Drivers.RabbitMQ.Message;
using FluentQueue.Interfaces.Message;

public class TestMessage : MessageBase, IRabbitMqMessage
{
    public TestMessage(object body, IMessageProperties? properties = null) : base(body, properties)
    {
        Exchange = new TestExchange();
        RoutingKey = null;
    }

    public IExchange? Exchange { get; set; }
    public string? RoutingKey { get; set; }
}
