using ScrubsDemo.Domain.Entities;

namespace ScrubsDemo.Application.Dto.PatientDto;

/// <summary>
/// Пациент без зависимых сущностей
/// </summary>
public record PatientWithoutDependenciesDto
{
    /// <summary>
    /// Имя пациента
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Фамилия пациента
    /// </summary>
    public string Surname { get; init; } = string.Empty;

    /// <summary>
    /// Отчество пациента (необязательное поле)
    /// </summary>
    public string? Patronymic { get; init; }

    /// <summary>
    /// Адрес проживания пациента
    /// </summary>
    public string Address { get; init; } = string.Empty;

    /// <summary>
    /// Дата рождения пациента
    /// </summary>
    public DateTime Birthday { get; init; }

    /// <summary>
    /// Пол пациента
    /// </summary>
    public Sex Sex { get; init; }

    /// <summary>
    /// Номер области, к которой привязан пациент
    /// </summary>
    public int AreaNumber { get; init; }    
}