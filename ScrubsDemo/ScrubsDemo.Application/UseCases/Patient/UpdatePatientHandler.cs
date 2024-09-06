using ScrubsDemo.Application.Dto.PatientDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Application.UseCases.Patient;

/// <summary>
/// Обработчик обновления пациента
/// </summary>
public class UpdatePatientHandler
{
    private readonly IPatientRepository _patientRepository;

    /// <summary>
    /// <inheritdoc cref="UpdatePatientHandler"/>
    /// </summary>
    public UpdatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    /// <summary>
    /// Обработать обновление пациента
    /// </summary>
    public async Task Handle(PatientWithoutDependenciesDto patientWithoutDependenciesDto)
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

        await _patientRepository.UpdatePatientAsync(patient);
    }        
}