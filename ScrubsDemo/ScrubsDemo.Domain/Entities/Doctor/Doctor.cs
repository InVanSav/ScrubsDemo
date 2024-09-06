namespace ScrubsDemo.Domain.Entities.Doctor;

/// <summary>
/// Доктор
/// </summary>
public record Doctor
{
    /// <summary>
    /// Полное имя врача (Фамилия Имя Отчество)
    /// </summary>
    public string FullName { get; init; } = string.Empty;
}