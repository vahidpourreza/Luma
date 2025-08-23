using Luma.Core.Contracts.ApplicationServices.Events;
using Luma.Utilities;
using Microsoft.AspNetCore.Http;

namespace Luma.EndPoints.Web.Extensions;

public static class HttpContextExtensions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));

    public static LumaServices LumaApplicationContext(this HttpContext httpContext) =>
        (LumaServices)httpContext.RequestServices.GetService(typeof(LumaServices));
}
