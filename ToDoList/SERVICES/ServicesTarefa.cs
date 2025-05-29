using ToDoList.DATA;
using ToDoList.ENTITY;

namespace ToDoList.SERVICES
{
    public class ServicesTarefa : IServiceTarefa
    {
        private readonly AppDbContext _context;
        public ServicesTarefa(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Tarefa> ObterTodasTarefas()
        {
            return _context.Tarefas.ToList();
        }
        public Tarefa? ObterTarefaPorId(int id)
        {
            return _context.Tarefas.Find(id);
        }
        public void AdicionarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }
        public void AtualizarTarefa(int id, Tarefa tarefa)
        {
            var tarefaExistente = ObterTarefaPorId(id);
            if (tarefaExistente != null)
            {
                tarefaExistente.titulo = tarefa.titulo;
                tarefaExistente.descricao = tarefa.descricao;
                tarefaExistente.concluida = tarefa.concluida;
                _context.SaveChanges();
            }
        }
        public void ConcluirTarefa(int id)
        {
            var tarefa = ObterTarefaPorId(id);
            if (tarefa != null)
            {
                tarefa.concluida = true;
                _context.SaveChanges();
            }
        }
    }
}
