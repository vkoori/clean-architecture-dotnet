namespace Infrastructure.Events;

using Coravel.Events.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class TransactionCommitted : IEvent
{
    private readonly List<EntityEntry> _Changes;

    public TransactionCommitted(DbContext dbContext)
    {
        _Changes = dbContext.ChangeTracker.Entries().ToList();
    }
}
