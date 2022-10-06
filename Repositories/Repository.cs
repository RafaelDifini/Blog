using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class // só aceita criaçao de repositorios genericos, onde o tipo seja uma classe
    {
        // private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        // => ExpressionBody, quando codigo tem apenas uma linha, pode ser usado no lugar de {} ou return
        => Database.Connection = connection;

        public IEnumerable<T> GetAll()
            => Database.Connection.GetAll<T>();

        public T Get(int id)
           => Database.Connection.Get<T>(id);

        public void Create(T model)
          => Database.Connection.Insert<T>(model);

        public void Update(T model)
              => Database.Connection.Update<T>(model);

        public void Delete(T model)
            => Database.Connection.Delete<T>(model);

        public void Delete(int id)
        {
            var model = Database.Connection.Get<T>(id);
            Database.Connection.Delete<T>(model);
        }
    }
}