namespace Application.Bus.Messages;

using FluentQueue.Interfaces.Message;

public abstract class MessageBase : IMessage
{
    public MessageBase(object body, IMessageProperties? properties = null)
    {
        Body = body;
        Properties = properties;
    }

    public object Body { get; set; }
    public IMessageProperties? Properties { get; set; }
}
