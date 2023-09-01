namespace Application.Scheduling;

using System.Threading.Tasks;
using Coravel.Invocable;
using Domain.Repositories.Marketing;

public class DbPartitioning : IInvocable
{
    IProcessedOrdersRepository _processedOrdersRepository;
    public DbPartitioning(IProcessedOrdersRepository processedOrdersRepository)
    {
        _processedOrdersRepository = processedOrdersRepository;
    }

    public async Task Invoke()
    {
        var now = DateTime.Now;

        if (!await _processedOrdersRepository.HasPartition(dateTime: now))
        {
            try
            {
                await _processedOrdersRepository.AddPartition(dateTime: now);
            }
            catch (System.Exception)
            {
                await _processedOrdersRepository.CreatePartition(dateTime: now);
            }
        }

        var nextMonth = now.AddMonths(months: 1);

        if (!await _processedOrdersRepository.HasPartition(dateTime: nextMonth))
        {
            await _processedOrdersRepository.AddPartition(dateTime: nextMonth);
        }
    }
}
