namespace API.Extensions.WebApplicationExt;

using Application.Scheduling;
using Coravel;
using Coravel.Scheduling.Schedule.Interfaces;

public static class SchedulerExtension
{
    public static void UseCustomScheduler(this WebApplication app)
    {
        app.Services.UseScheduler(scheduler =>
        {
            scheduler.Schedule<DbPartitioning>().Weekly().RunOnceAtStart();
        }).LogScheduledTaskProgress(app.Services.GetService<ILogger<IScheduler>>());;

    }
}
