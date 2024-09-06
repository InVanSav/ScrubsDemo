using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace ScrubsDemo.Database.MsSql;

/// <summary>
/// Класс для работы с базой данных MsSql
/// </summary>
public class MsSqlHandler
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    private readonly string _connectionString;

    /// <summary>
    /// Основной путь к ресурсу скрипта
    /// </summary>
    private const string ResourcePath = "ScrubsDemo.Database.MsSql.Scripts.";

    /// <summary>
    /// <inheritdoc cref="MsSqlHandler"/>
    /// </summary>
    /// <param name="connectData">Данные класса со строкой подключения из файла конфигурации</param>
    public MsSqlHandler(IOptions<MsSqlConnection> connectData)
    {
        _connectionString = connectData.Value.GetConnectionString();
    }

    /// <summary>
    /// Выполнить запрос без возвращаемых данных
    /// </summary>
    /// <param name="resourceName">Имя скрипта</param>
    /// <param
    ///     name="commandParameters">Массив параметров для команды
    ///             (string - Название параметра, object - Параметр)
    /// </param>
    public async Task ExecuteAsync(string resourceName, params KeyValuePair<string, object>[] commandParameters)
    {
        var command = await PrepareAsync(resourceName, commandParameters);

        await command.ExecuteNonQueryAsync();
        await command.DisposeAsync();
    }

    /// <summary>
    /// Выполнить запрос на получение одной записи из базы данных
    /// </summary>
    /// <param name="resourceName">Имя скрипта</param>
    /// <param name="selector">Делегат, задающий конструктор для создания сущности из прочтенных данных</param>
    /// <param
    ///     name="commandParameters">Массив параметров для команды
    ///             (string - Название параметра, object - Параметр)
    /// </param>
    public async Task<T> ReadAsync<T>(string resourceName, Func<SqlDataReader, T> selector, 
        params KeyValuePair<string, object>[] commandParameters)
    {
        var command = await PrepareAsync(resourceName, commandParameters);

        await using var dataReader = await command.ExecuteReaderAsync();

        await command.DisposeAsync();        

        await dataReader.ReadAsync();
        var entity = selector(dataReader);

        return entity;
    }

    /// <summary>
    /// Выполнить запрос на получение списка записей
    /// </summary>
    /// <param name="resourceName">Имя скрипта</param>
    /// <param name="selector">Делегат, задающий конструктор для создания сущности из прочтенных данных</param>
    /// <param
    ///     name="commandParameters">Массив параметров для команды
    ///             (string - Название параметра, object - Параметр)
    /// </param>
    /// <typeparam name="T">Сущность</typeparam>
    /// <returns>Список сущностей</returns>
    public async Task<IReadOnlyCollection<T>> ReadManyByParametersAsync<T>(string resourceName,
        Func<SqlDataReader, T> selector,
        params KeyValuePair<string, object>[] commandParameters)
    {
        var command = await PrepareAsync(resourceName, commandParameters);

        await using var dataReader = await command.ExecuteReaderAsync();

        var entities = new List<T>();
        while (await dataReader.ReadAsync())
        {
            var entity = selector(dataReader);
            entities.Add(entity);
        }

        return entities;
    }    

    private async Task<SqlCommand> PrepareAsync(string resourceName, params KeyValuePair<string, object>[] commandParameters)
    {
        var commandText = AssemblyReader.GetScript(ResourcePath + resourceName);

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(commandText, connection);

        foreach (var commandParameter in commandParameters)
        {
            command.Parameters.AddWithValue(commandParameter.Key, commandParameter.Value);
        }

        return command;
    }
}