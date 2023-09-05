namespace Application.Services.Interfaces.V1.AuditLog;

using System.Threading.Tasks;

public interface IAuditLog
{
    Task SaveLog(ulong userId, string corelationId, string eventType, string eventMessage);
}
