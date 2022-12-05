namespace Board.Api.Infrastructure.Features;

public class EntityTagHandlerFeature : IEntityTagHandlerFeature
{
    private readonly IHeaderDictionary _headers;

    public EntityTagHandlerFeature(IHeaderDictionary headers)
    {
        _headers = headers;
    }

    public bool Match(IEntityTaggable entity)
    {
        if (!_headers.TryGetValue("If-Match", out var entityTagHeader))
            return false;

        var entityTag = entity.GetEntityTag();

        if (string.IsNullOrEmpty(entityTag))
            return false;

        return entityTagHeader.Equals(entityTag);
    }
}