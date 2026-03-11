using System.Data;
using System.Data.SqlClient;

public abstract class BaseRepository
{
    private readonly string _connectionString;

    protected BaseRepository(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string 'DefaultConnection' not found", nameof(connectionString));

        _connectionString = connectionString;
    }

    protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}