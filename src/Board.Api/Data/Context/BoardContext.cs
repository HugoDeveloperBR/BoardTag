using Board.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Board.Api.Data.Context;

public class BoardContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Board");
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}