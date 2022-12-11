using System.Data;

namespace TarefaDemo.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
