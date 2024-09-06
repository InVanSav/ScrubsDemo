namespace ScrubsDemo.Domain.Entities.Doctor;

/// <summary>
/// Врач без зависимых сущностей
/// </summary>
public record DoctorWithoutDependencies : Doctor
{
    /// <summary>
    /// Номер кабинета, в котором работает врач
    /// </summary>
    public int Office { get; init; }

    /// <summary>
    /// Идентификатор специализации врача
    /// </summary>
    public int Specialization { get; init; }

    /// <summary>
    /// Номер области, к которой привязан врач
    /// </summary>
    public int Area { get; init; }
}

