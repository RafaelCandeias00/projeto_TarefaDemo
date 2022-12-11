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

            app.MapGet("/tarefas/{id:int}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                /*var tarefa = con.Get<Tarefa>(id);
                if (tarefa is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(tarefa);*/

                return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound();
            });

            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(tarefa);
                return Results.Created($"/tarefas/{id}", tarefa);
            });

            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(tarefa);
                return Results.Ok();
            });

            app.MapDelete("/tarefas/{id:int}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var deletado = con.Get<Tarefa>(id);
                if (deletado is null)
                {
                    return Results.NotFound();
                }
                con.Delete(deletado);
                return Results.Ok(deletado);
            });
        }
    }
}
