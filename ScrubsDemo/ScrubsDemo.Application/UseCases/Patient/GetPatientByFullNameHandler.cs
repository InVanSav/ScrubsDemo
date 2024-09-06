using ScrubsDemo.Application.Dto.PatientDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Application.UseCases.Patient;

/// <summary>
/// Обработчик получения пациента по ФИО
/// </summary>
public class GetPatientByFullNameHandler
{
    private readonly IPatientRepository _patientRepository;

    /// <summary>
    /// <inheritdoc cref="GetPatientByFullNameHandler"/>
    /// </summary>
    public GetPatientByFullNameHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    /// <summary>
    /// Обработать получение пациента по ФИО
    /// </summary>
    public async Task<PatientWithoutDependenciesDto> HandleAsync(string name, string surname, string? patronymic)
    {
        var patient = await _patientRepository.GetPatientByFullNameAsync(name, surname, patronymic);

        return new PatientWithoutDependenciesDto
        {
            Name = patient.Name,
            Surname = patient.Surname,
            Patronymic = patient.Patronymic,
            Address = patient.Address,
            Birthday = patient.Birthday,
            Sex = patient.Sex,
            AreaNumber = patient.AreaNumber
        };
    }
}