using System.Data.SqlClient;
using static TarefaDemo.Data.TarefaContext;

namespace TarefaDemo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<GetConnection>(sp => async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });

            return builder;
        }
    }
}
