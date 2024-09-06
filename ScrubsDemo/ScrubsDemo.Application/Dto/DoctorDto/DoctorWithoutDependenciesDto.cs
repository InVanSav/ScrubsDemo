namespace ScrubsDemo.Application.Dto.DoctorDto;

/// <summary>
/// Доктор без зависимых сущностей
/// </summary>
public record DoctorWithoutDependenciesDto
{
    /// <summary>
    /// Полное имя врача (Фамилия Имя Отчество)
    /// </summary>
    public string FullName { get; init; } = string.Empty;

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