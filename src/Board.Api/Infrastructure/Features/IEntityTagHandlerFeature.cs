namespace Board.Api.Infrastructure.Features;

public interface IEntityTagHandlerFeature
{
    bool Match(IEntityTaggable entity);
}