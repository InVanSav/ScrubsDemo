namespace ScrubsDemo.Database.MsSql;

/// <summary>
/// Класс строки подключения базы данных MsSql
/// </summary>
public class MsSqlConnection
{
    /// <summary>
    /// Название сервера
    /// </summary>
    public string DataSource { get; set; }

    /// <summary>
    /// Название базы данных
    /// </summary>
    public string InitialCatalog { get; set; }

    /// <summary>
    /// Проверка подлинности
    /// </summary>
    public bool IntegratedSecurity { get; set; }

    /// <summary>
    /// Получить строку подключения к базе данных
    /// </summary>
    /// <returns>Строку подключения к базе данных MsSql</returns>
    public string GetConnectionString()
    {
        return  $"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security={IntegratedSecurity}";
    }
}