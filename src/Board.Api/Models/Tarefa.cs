using Board.Api.Infrastructure;
using Newtonsoft.Json;

namespace Board.Api.Models;

public class Tarefa : IEntityTaggable
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public string GetEntityTag()
    {
        var serialize = JsonConvert.SerializeObject(this);
        return HashGenerator.Generate(serialize);
    }
}