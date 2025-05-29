using Microsoft.AspNetCore.Mvc;
using ToDoList.ENTITY;
using ToDoList.SERVICES;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/Tarefas")]
    public class TarefaController : Controller
    {
       private readonly IServiceTarefa _serviceTarefa;
        public TarefaController(IServiceTarefa serviceTarefa)
        {
            _serviceTarefa = serviceTarefa;
        }
        [HttpGet ("ObterTodas")]
        public IActionResult ObterTodasTarefas()
        {
            var tarefas = _serviceTarefa.ObterTodasTarefas();
            return Ok(new
            {
                Mensagem = "Sucesso",
                Quantidade = tarefas.Count(),
                Tarefas = tarefas
            }
                );
        }
        [HttpGet("ObterTodasP/ID {id}")]
        public IActionResult ObterTarefaPorId(int id)
        {
            var tarefa = _serviceTarefa.ObterTarefaPorId(id);
            if (tarefa == null)
            {
                return NotFound(new
                {
                    Mensagem = "Tarefa não encontrada",
                    Id = id
                });
            }
            return Ok(new
            {
                Mensagem = "Tarefa encontrada",
                Tarefa = tarefa
            });
        }
        [HttpPost("CriarNovaTarefa")]
        public IActionResult AdicionarTarefa([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Tarefa inválida. Por favor, forneça os dados necessários."
                });
            }
            _serviceTarefa.AdicionarTarefa(tarefa);
            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.id }, tarefa);
        }
        [HttpPut("AtualizarTarefaP/ID{id}")]
        public IActionResult AtualizarTarefa(int id, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null || tarefa.id != id)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados inválidos. Por favor, forneça os dados corretos para atualização."
                });
            }
            _serviceTarefa.AtualizarTarefa(id, tarefa);
            return Ok(new
            {
                Mensagem = "Tarefa atualizada com sucesso",
                Tarefa = tarefa
            });
        }
        [HttpPost("Concluir/{id}")]
        public IActionResult ConcluirTarefa(int id)
        {
            _serviceTarefa.ConcluirTarefa(id);
            return Ok(new
            {
                Mensagem = "Tarefa concluída com sucesso",
                Id = id
            });
        }
    }
}
