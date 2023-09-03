namespace Infrastructure.Listeners;

using System.Threading.Tasks;
using Coravel.Events.Interfaces;
using Infrastructure.Events;

public class SaveCommittedLog : IListener<TransactionCommitted>
{
    public async Task HandleAsync(TransactionCommitted transactionCommitted)
    {
        await Task.Delay(50);
    }
}
