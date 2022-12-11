using TarefaDemo.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.AddPersistence();

app.Run();
