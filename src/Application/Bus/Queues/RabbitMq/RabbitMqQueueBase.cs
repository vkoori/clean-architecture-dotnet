namespace Application.Bus.Queues.RabbitMq;

using System.Collections.Generic;
using FluentQueue.Interfaces.Drivers.RabbitMQ.Queue;

public abstract class RabbitMqQueueBase : IRabbitMqQueue
{
    public abstract string QueueName { get; set; }
    public bool Durable { get; set; } = true;
    public bool Exclusive { get; set; } = false;
    public bool AutoDelete { get; set; } = false;
    public IDictionary<string, object>? Arguments { get; set; } = new Dictionary<string, object>();
}
