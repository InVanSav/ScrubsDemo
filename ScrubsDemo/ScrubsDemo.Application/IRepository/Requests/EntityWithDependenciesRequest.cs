namespace ScrubsDemo.Application.IRepository.Requests;

/// <summary>
/// Модель запроса получения сущности с зависимостями
/// </summary>
public record EntityWithDependenciesRequest
{
    /// <summary>
    /// Название столбца для сортировки
    /// </summary>
    public string SortingColumn { get; init; } = string.Empty;

    /// <summary>
    /// Отступ от начала
    /// </summary>
    public string Offset { get; init; } = string.Empty;

    /// <summary>
    /// Количество
    /// </summary>
    public string Limit { get; init; } = string.Empty;    
}