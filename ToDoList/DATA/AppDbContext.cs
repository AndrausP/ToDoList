using Microsoft.EntityFrameworkCore;
using ToDoList.ENTITY;

namespace ToDoList.DATA
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
       
    }
}
