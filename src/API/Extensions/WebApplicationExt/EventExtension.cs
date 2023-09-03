namespace API.Extensions.WebApplicationExt;

using Coravel;
using Coravel.Events.Interfaces;
using Infrastructure.Events;
using Infrastructure.Listeners;

public static class EventExtension
{
    public static void UseCustomEvents(this WebApplication app)
    {
        IEventRegistration registration = app.Services.ConfigureEvents();

        registration
            .Register<TransactionCommitted>()
            .Subscribe<SaveCommittedLog>();
        registration
            .Register<TransactionRollbacked>()
            .Subscribe<SaveRollbackedLog>();
    }
}
