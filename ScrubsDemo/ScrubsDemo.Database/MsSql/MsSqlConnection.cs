namespace ScrubsDemo.Database.MsSql;

/// <summary>
/// Класс строки подключения базы данных MsSql
/// </summary>
public class MsSqlConnection
{
    /// <summary>
    /// Название сервера
    /// </summary>
    public string Server { get; set; }

    /// <summary>
    /// Название базы данных
    /// </summary>
    public string Database { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Получить строку подключения к базе данных
    /// </summary>
    /// <returns>Строку подключения к базе данных MsSql</returns>
    public string GetConnectionString()
    {
        return  $"Server={Server};Database={Database};User Id={UserId};Password={Password};";
    }
}