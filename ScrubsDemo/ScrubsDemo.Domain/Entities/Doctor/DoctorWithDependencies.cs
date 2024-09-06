namespace ScrubsDemo.Domain.Entities.Doctor;

/// <summary>
/// Врач с зависимыми сущностями
/// </summary>
public record DoctorWithDependencies : Doctor
{
    /// <summary>
    /// Номер кабинета, в котором работает врач
    /// </summary>
    public Office Office { get; init; }

    /// <summary>
    /// Идентификатор специализации врача
    /// </summary>
    public Specialization Specialization { get; init; }

    /// <summary>
    /// Номер области, к которой привязан врач
    /// </summary>
    public Area Area { get; init; }
}