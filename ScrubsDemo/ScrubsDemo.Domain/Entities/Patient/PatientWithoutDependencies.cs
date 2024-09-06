namespace ScrubsDemo.Domain.Entities.Patient;

/// <summary>
/// Пациент без зависимых сущностей
/// </summary>
public record PatientWithoutDependencies : Patient
{
    /// <summary>
    /// Номер области, к которой привязан пациент
    /// </summary>
    public int AreaNumber { get; init; }
}

