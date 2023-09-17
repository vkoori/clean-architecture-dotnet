namespace Application.Bus.Jobs;

using System;
using System.Threading.Tasks;
using Application.Bus.Messages.Body;
using FluentQueue.Interfaces.Job;

public class TestJob : IInvocableJob<TestMessageBody>
{
    public Task FailedJob(TestMessageBody message, object? properties)
    {
        throw new NotImplementedException();
    }

    public async Task Invoke(TestMessageBody message, string? correlationId)
    {
        System.Console.WriteLine("message consumed");
        await Task.CompletedTask;
    }
}
