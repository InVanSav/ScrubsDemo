namespace ScrubsDemo.Domain.Entities.Patient;

/// <summary>
/// Пациент с зависимыми сущностями
/// </summary>
public record PatientWithDependencies : Patient
{
    /// <summary>
    /// Номер области, к которой привязан пациент
    /// </summary>
    public Area AreaNumber { get; init; }
}