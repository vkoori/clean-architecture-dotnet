namespace API.Extensions.MvcOptionsExt;

using System.Diagnostics;
using Infrastructure.Observer;
using Microsoft.AspNetCore.Mvc.Filters;

public class QueryLoggerAction : ActionFilterAttribute
{
    private const string QueryLoggerDiagnosticKey = "audit_log_disposable_key";

    public override void OnActionExecuting(ActionExecutingContext context)
    {

        IDisposable auditLogDisposable = DiagnosticListener.AllListeners.Subscribe(
            observer: new AuditLogObserver()
        );

        context.HttpContext.Items[QueryLoggerDiagnosticKey] = auditLogDisposable;

        base.OnActionExecuting(context: context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Items.TryGetValue(QueryLoggerDiagnosticKey, out object? diagnostic) && diagnostic is IDisposable auditLogDisposable)
        {
            auditLogDisposable?.Dispose();
        }

        base.OnActionExecuted(context: context);
    }
}
