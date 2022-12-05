using Board.Api.Infrastructure.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Board.Api.Infrastructure.Filters;

public class EntityTagHeaderFilter : IAsyncActionFilter
{
    private const string HeaderName = "ETag";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Features
            .Set<IEntityTagHandlerFeature>(
                new EntityTagHandlerFeature(context.HttpContext.Request.Headers));

        var executed = await next();

        var result = executed.Result as ObjectResult;

        var entityTag = (result?.Value as IEntityTaggable)?.GetEntityTag();

        if (string.IsNullOrEmpty(entityTag))
            return;

        context.HttpContext.Response.Headers.Add(HeaderName, entityTag);

        await Task.CompletedTask;
    }
}