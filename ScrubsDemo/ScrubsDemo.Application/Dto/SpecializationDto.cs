namespace ScrubsDemo.Application.Dto;

/// <summary>
/// Специализация
/// </summary>
public record SpecializationDto
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