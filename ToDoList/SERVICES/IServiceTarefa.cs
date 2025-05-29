using ToDoList.ENTITY;

namespace ToDoList.SERVICES
{
    public interface IServiceTarefa
    {
        public IEnumerable<Tarefa> ObterTodasTarefas();
        public Tarefa? ObterTarefaPorId(int id);
        public void AdicionarTarefa(Tarefa tarefa);
        public void AtualizarTarefa(int id,Tarefa tarefa); 
        public void ConcluirTarefa(int id);
    }
}
