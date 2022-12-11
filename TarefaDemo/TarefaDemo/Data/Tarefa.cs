using System.ComponentModel.DataAnnotations.Schema;

namespace TarefaDemo.Data
{
    [Table("Tarefas")]
    public record Tarefa(int Id, string Atividade, string Status);
}
