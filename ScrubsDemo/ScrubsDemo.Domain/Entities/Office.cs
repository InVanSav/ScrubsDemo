namespace ScrubsDemo.Domain.Entities;

/// <summary>
/// Офис или кабинет врача
/// </summary>
public record Office
{
    /// <summary>
    /// Уникальный номер кабинета
    /// </summary>
    public int Number { get; init; }
}