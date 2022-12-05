using Board.Api.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Board.Api.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ETagAttribute : Attribute, IFilterFactory
{
    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        return new EntityTagHeaderFilter();
    }

    public bool IsReusable => true;
}