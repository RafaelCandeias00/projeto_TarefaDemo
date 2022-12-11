using Dapper.Contrib.Extensions;
using TarefaDemo.Data;
using static TarefaDemo.Data.TarefaContext;

namespace TarefaDemo.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem Vindo a API Tarefas - {DateTime.Now}");

            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();
                if(tarefas is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(tarefas);
            });
        }
    }
}
