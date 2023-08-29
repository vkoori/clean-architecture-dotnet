namespace Infrastructure.Persistance.ClickHouseConnection;

using ClickHouse.Ado;

public class ClickHouseContext : ClickHouseConnection
{
    // public DbSet<YourEntity> YourEntities { get; set; }

    public ClickHouseContext(string connectionString) : base(connectionString)
    {
    }
}
