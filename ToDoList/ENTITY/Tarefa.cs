namespace ToDoList.ENTITY
{
    public class Tarefa
    {
        public int id { get; set; }
        public string titulo { get; set; } = null!;
        public string descricao { get; set; } = null!;
        public bool concluida { get; set; } = false;
    }
}
