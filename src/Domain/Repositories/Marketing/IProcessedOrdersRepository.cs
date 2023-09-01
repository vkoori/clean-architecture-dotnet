namespace Domain.Repositories.Marketing;

public interface IProcessedOrdersRepository
{
    Task CreatePartition(DateTime dateTime);
    Task AddPartition(DateTime dateTime);
    Task<bool> HasPartition(DateTime dateTime);
}
