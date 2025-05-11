using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;
using Users;

namespace UserRepository;

public class UsersRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UsersRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<long> AddInform(string pin, long balance)
    {
        const string sql = """
                           INSERT INTO users (pin, balance)
                           VALUES (@pin, @balance)
                           RETURNING user_id;
                           """;

        using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        if (connection.State == System.Data.ConnectionState.Closed)
        {
            await connection.OpenAsync().ConfigureAwait(false);
        }

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@pin", pin);
        command.Parameters.AddWithValue("@balance", balance);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            long userId = reader.GetInt64(0);
            await connection.CloseAsync().ConfigureAwait(false);
            return userId;
        }

        await connection.CloseAsync().ConfigureAwait(false);
        return 0;
    }

    public async Task<long> UpdateInform(long userId, long balance)
    {
        const string sql = """
                           UPDATE users
                           SET balance = @balance
                           WHERE user_id = @userId
                           RETURNING balance;
                           """;

        using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        if (connection.State == System.Data.ConnectionState.Closed)
        {
            await connection.OpenAsync().ConfigureAwait(false);
        }

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@balance", balance);
        command.Parameters.AddWithValue("@userId", userId);

        long updatedBalance = (long)(await command.ExecuteScalarAsync().ConfigureAwait(false) ?? 0);
        await connection.CloseAsync().ConfigureAwait(false);
        return updatedBalance;
    }

    public async Task<IUser?> FindUserByUserId(long userid)
    {
        const string sql = """
                           SELECT user_id, pin, balance
                           FROM users
                           WHERE user_id = @userid;
                           """;

        using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        if (connection.State == System.Data.ConnectionState.Closed)
        {
            await connection.OpenAsync().ConfigureAwait(false);
        }

        try
        {
            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userid", NpgsqlTypes.NpgsqlDbType.Bigint, userid);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            if (!reader.HasRows)
                return null;

            if (await reader.ReadAsync().ConfigureAwait(false))
            {
                var current = new User(
                    number: reader.GetInt64(0),
                    pin: reader.GetString(1));
                current.RedefineBalance(reader.GetInt64(2));
                return current;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}