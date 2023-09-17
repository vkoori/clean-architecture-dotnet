namespace API.Extensions.ServiceCollectionExt;

using FluentQueue;
using FluentQueue.Implementation.Connection;
using FluentQueue.Implementation.Drivers.RabbitMq.Connection;
using FluentQueue.Interfaces.Queue;
using Application.Bus.Queues.RabbitMq;

public static class BusServicesRegistration
{
    public static void AddBus(this IServiceCollection services)
    {
        services.AddMessageBus(
            connections: new Dictionary<string, BaseBusConnectionDtoAbstract>
            {
                {
                    "LocalRabbit",
                    new RabbitMqConnectionDto{
                        HostName = "127.0.0.1",
                        Port = 5672,
                        UserName = "guest",
                        Password = "guest",
                        VirtualHost = "/"
                    }
                }
            },
            defaultConnection: "LocalRabbit"
        ).AddSubscriberBus(
            queues: new List<IQueue>{
                new TestQueue()
            },
            connectionName: "LocalRabbit",
            retry: 3,
            consumerCount: 1
        );
    }
}
