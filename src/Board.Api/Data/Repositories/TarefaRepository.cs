using Board.Api.Data.Context;
using Board.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Board.Api.Data.Repositories;

public class TarefaRepository : ITarefaRepository
{
    public TarefaRepository()
    {
        using var context = new BoardContext();

        var tarefas = new List<Tarefa>
        {
            new Tarefa
            {
                Id = 1,
                Titulo = "Adicionar paginação na consulta de tarefas",
                Descricao = "Adicionar paginação na listagem de tarefas."
            },
            new Tarefa
            {
                Id = 2,
                Titulo = "Adicionar ordenação na consulta de tarefas",
                Descricao = "Adicionar ordenação na listagem de tarefas."
            },
            new Tarefa
            {
                Id = 3,
                Titulo = "Adicionar filtro por titulo na consulta de tarefa",
                Descricao = "Adicionar filtro por titulo na consulta de tarefa."
            }
        };

        foreach (var tarefa in tarefas)
        {
            if (context.Tarefas.Contains(tarefa)) 
                continue;

            context.Tarefas.Add(tarefa);
            context.SaveChanges();
        }
    }

    public async Task<Tarefa?> BuscarPorId(int id)
    {
        await using var context = new BoardContext();
        return context.Tarefas.FirstOrDefault(x => x != null && x.Id == id);
    }

    public async Task Atualizar(int id, Tarefa model)
    {
        await using var context = new BoardContext();
        var tarefa = await context.Tarefas.SingleOrDefaultAsync(x => x.Id == id);

        if (tarefa != null)
        {
            tarefa.Titulo = model.Titulo;
            tarefa.Descricao = model.Descricao;
            
            await context.SaveChangesAsync();
        }
    }
}