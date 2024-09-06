namespace ScrubsDemo.Application.Dto;

/// <summary>
/// Офис или кабинет врача
/// </summary>
public record OfficeDto
{
    /// <summary>
    /// Уникальный номер кабинета
    /// </summary>
    public int Number { get; init; }
}