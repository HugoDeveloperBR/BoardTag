using Board.Api.Data.Repositories;
using Board.Api.Infrastructure;
using Board.Api.Infrastructure.Attributes;
using Board.Api.Infrastructure.Extensions;
using Board.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Resources;

namespace Board.Api.Controllers;

[ApiController]
[Route("api/tarefas")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefaController(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    [ETag]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(id);
        
        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }

    [ETag]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Tarefa model)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(id);

        if (tarefa == null)
            return NotFound();

        if (Request.GetEntityTagHandler().Match(tarefa))
        {
            model.Id = id;

            await _tarefaRepository.Atualizar(model);
            return Ok(model);
        }

        var resource = new ResourceManager(typeof(Resource));

        var message = resource.GetString("PreconditionFailedMessage");
        var result = JsonConvert.SerializeObject(message);

        return await Task.FromResult(StatusCode((int)HttpStatusCode.PreconditionFailed, result));
    }
}