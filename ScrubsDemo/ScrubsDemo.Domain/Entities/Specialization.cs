namespace ScrubsDemo.Domain.Entities;

/// <summary>
/// Медицинская специализацию
/// </summary>
public record Specialization
{
    /// <summary>
    /// Уникальный идентификатор специализации
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Название специализации
    /// </summary>
    public string Name { get; init; } = string.Empty;
}

