namespace ScrubsDemo.Application.Dto;

/// <summary>
/// Представляет административную или географическую область
/// </summary>
public record AreaDto
{
    /// <summary>
    /// Уникальный идентификатор области
    /// </summary>
    public int Number { get; init; }
}