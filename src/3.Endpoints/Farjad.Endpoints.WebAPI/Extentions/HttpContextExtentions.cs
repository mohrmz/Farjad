using Farjad.Core.Contracts.ApplicationServices.Commands;
using Farjad.Core.Contracts.ApplicationServices.Events;
using Farjad.Core.Contracts.ApplicationServices.Queries;
using Farjad.Utilities;

namespace Farjad.Endpoints.WebApi.Extentions;

public static class HttpContextExtentions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));

    public static FarjadServices FarjadApplicationContext(this HttpContext httpContext) =>
        (FarjadServices)httpContext.RequestServices.GetService(typeof(FarjadServices));
}