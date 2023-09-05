namespace Infrastructure.Repositories.AuditLog;

using System.Threading.Tasks;
using Application.Services.Interfaces.V1.AuditLog;
using Microsoft.VisualBasic;

public class AuditLog : IAuditLog
{
    public async Task SaveLog(ulong userId, string corelationId, string eventType, string eventMessage)
    {
        var createdAt = DateAndTime.Now;

        await Task.Delay(50);
    }
}
