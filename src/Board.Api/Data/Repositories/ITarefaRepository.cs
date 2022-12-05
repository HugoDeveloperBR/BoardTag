using Board.Api.Models;

namespace Board.Api.Data.Repositories;

public interface ITarefaRepository
{
    Task<Tarefa?> BuscarPorId(int id);
    Task Atualizar(int id, Tarefa model);
}