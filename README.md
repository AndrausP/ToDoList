# ✅ ToDoList

Um projeto simples de **To-Do List** criado com **ASP.NET Core** e **Entity Framework Core**, usando arquitetura em camadas (DATA / ENTITY / SERVICES). Ideal para praticar operações básicas de CRUD com banco de dados — e para nunca mais esquecer suas tarefas! 🧠💡

> Repositório oficial: [github.com/AndrausP/ToDoList](https://github.com/AndrausP/ToDoList)

---

## 📦 Estrutura do Projeto

- `ToDoList.DATA` — Contexto do banco de dados (`AppDbContext`)
- `ToDoList.ENTITY` — Entidade `Tarefa`
- `ToDoList.SERVICES` — Regras de negócio com `ServicesTarefa`

---

## 🧱 Modelo da Entidade

```csharp
public class Tarefa
{
    public int id { get; set; }
    public string titulo { get; set; } = null!;
    public string descricao { get; set; } = null!;
    public bool concluida { get; set; } = false;
}
