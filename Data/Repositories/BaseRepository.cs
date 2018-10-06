using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BaseRepository
    {
        private readonly IConnectionFactory connection;

        protected BaseRepository(IConnectionFactory factory)
        {
            connection = factory;
        }

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var cn = connection.GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    return await getData(cn).ConfigureAwait(false);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (MySqlException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }
    }
}
