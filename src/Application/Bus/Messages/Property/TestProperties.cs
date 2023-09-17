namespace Application.Bus.Messages.Property;

using System;
using FluentQueue.Interfaces.Message;

public class TestProperties : IMessageProperties
{
    public string? CorrelationId { get; set; }
    public DateTime? Expiration { get; set; }
}
