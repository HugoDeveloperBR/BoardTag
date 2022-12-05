using Board.Api.Data.Repositories;
using Board.Api.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(id);
        
        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] Tarefa model)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(id);

        if (tarefa == null)
            return NotFound();

        await _tarefaRepository.Atualizar(id, model);

        return Ok(model);
    }
}