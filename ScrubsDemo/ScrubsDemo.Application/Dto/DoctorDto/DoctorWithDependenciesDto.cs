namespace ScrubsDemo.Application.Dto.DoctorDto;

/// <summary>
/// Доктор с зависимыми сущностями
/// </summary>
public record DoctorWithDependenciesDto
{
    /// <summary>
    /// Полное имя врача (Фамилия Имя Отчество)
    /// </summary>
    public string FullName { get; init; } = string.Empty;

    /// <summary>
    /// Номер кабинета, в котором работает врач
    /// </summary>
    public OfficeDto Office { get; init; }

    /// <summary>
    /// Идентификатор специализации врача
    /// </summary>
    public SpecializationDto Specialization { get; init; }

    /// <summary>
    /// Номер области, к которой привязан врач
    /// </summary>
    public AreaDto Area { get; init; }    
}