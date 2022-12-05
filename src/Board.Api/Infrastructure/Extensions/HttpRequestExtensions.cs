using Board.Api.Infrastructure.Features;

namespace Board.Api.Infrastructure.Extensions;

public static class HttpRequestExtensions
{
    public static IEntityTagHandlerFeature GetEntityTagHandler(this HttpRequest request)
    {
        return request.HttpContext.Features.Get<IEntityTagHandlerFeature>()!;
    }
}