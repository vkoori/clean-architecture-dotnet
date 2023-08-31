namespace Domain.Entities;

using System;

public class BaseEntity
{
    public ulong Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
