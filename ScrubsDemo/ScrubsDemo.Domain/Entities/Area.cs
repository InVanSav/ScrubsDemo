namespace ScrubsDemo.Domain.Entities;

/// <summary>
/// Представляет административную или географическую область
/// </summary>
public record Area
{
    /// <summary>
    /// Уникальный идентификатор области
    /// </summary>
    public int Number { get; init; }
}
