namespace Infrastructure.Repositories.Marketing;

using Infrastructure.Persistance.EFCore;
using Domain.Entities.Marketing;
using Domain.Repositories.Marketing;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

public class ProcessedOrdersRepository : IProcessedOrdersRepository
{

    private readonly DbContext _dbContext;
    private readonly DbSet<ProcessedOrders> _dbSet;

    public ProcessedOrdersRepository(MarketingDbContext marketingDbContext)
    {
        _dbContext = marketingDbContext;
        _dbSet = marketingDbContext.Set<ProcessedOrders>();
    }

    public async Task CreatePartition(DateTime dateTime)
    {
        string tableName = ProcessedOrdersConfiguration.TableName;
        string partitionName = GetPartitionName(dateTime: dateTime);
        string partitionLessThan = GetPartitionLessThan(dateTime: dateTime);

        string sql = @$"ALTER TABLE `{tableName}` 
        PARTITION BY RANGE(YEAR(created_at) * 100 + MONTH(created_at)) 
        ( 
            PARTITION p{partitionName} VALUES LESS THAN ({partitionLessThan})
        );";

        await _dbContext.Database.ExecuteSqlRawAsync(sql: sql);
    }

    public async Task AddPartition(DateTime dateTime)
    {
        string tableName = ProcessedOrdersConfiguration.TableName;
        string partitionName = GetPartitionName(dateTime: dateTime);
        string partitionLessThan = GetPartitionLessThan(dateTime: dateTime);

        string sql = @$"ALTER TABLE `{tableName}` 
        ADD PARTITION 
        ( 
            PARTITION p{partitionName} VALUES LESS THAN ({partitionLessThan})
        );";

        await _dbContext.Database.ExecuteSqlRawAsync(sql: sql);
    }

    public async Task<bool> HasPartition(DateTime dateTime)
    {
        string tableName = ProcessedOrdersConfiguration.TableName;
        string partitionName = GetPartitionName(dateTime: dateTime);

        string sql = $"SELECT * FROM {tableName} PARTITION ({partitionName}) LIMIT 1";

        try
        {
            await _dbContext.Database.ExecuteSqlRawAsync(sql: sql);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    private static string GetPartitionName(DateTime dateTime)
    {
        return dateTime.ToString("yyyyMM");
    }

    private static string GetPartitionLessThan(DateTime dateTime)
    {
        return dateTime.AddMonths(1).ToString("yyyyMM");
    }
}
