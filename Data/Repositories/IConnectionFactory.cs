using MySql.Data.MySqlClient;

namespace Data
{
    public interface IConnectionFactory
    {
        MySqlConnection Connection { get; }
    }
}
