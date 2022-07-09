using Scorpion.Core.Contracts.ApplicationServices.Commands;
using Scorpion.Core.Contracts.ApplicationServices.Events;
using Scorpion.Core.Contracts.ApplicationServices.Queries;
using Scorpion.Utilities;

namespace Scorpion.Endpoints.WebApi.Extentions;

public static class HttpContextExtentions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));
    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));
    public static ScorpionServices ScoprionApplicationContext(this HttpContext httpContext) =>
        (ScorpionServices)httpContext.RequestServices.GetService(typeof(ScorpionServices));
}