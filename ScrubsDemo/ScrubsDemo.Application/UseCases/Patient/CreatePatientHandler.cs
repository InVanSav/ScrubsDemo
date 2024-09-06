using ScrubsDemo.Application.Dto.PatientDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Application.UseCases.Patient;

/// <summary>
/// Обработчик создания пациента
/// </summary>
public class CreatePatientHandler
{
    private readonly IPatientRepository _patientRepository;

    /// <summary>
    /// <inheritdoc cref="CreatePatientHandler"/>
    /// </summary>
    public CreatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    /// <summary>
    /// Обработать создание пациента
    /// </summary>
    public async Task HandleAsync(PatientWithoutDependenciesDto patientWithoutDependenciesDto)
    {
        var patient = new PatientWithoutDependencies
        {
            Name = patientWithoutDependenciesDto.Name,
            Surname = patientWithoutDependenciesDto.Surname,
            Patronymic = patientWithoutDependenciesDto.Patronymic,
            Address = patientWithoutDependenciesDto.Address,
            AreaNumber = patientWithoutDependenciesDto.AreaNumber,
            Birthday = patientWithoutDependenciesDto.Birthday,
            Sex = patientWithoutDependenciesDto.Sex
        };

        await _patientRepository.CreatePatientAsync(patient);
    }
}