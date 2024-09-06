using ScrubsDemo.Application.Dto;
using ScrubsDemo.Application.Dto.PatientDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Application.UseCases.Patient;

/// <summary>
/// Обработчик получения списка пациентов с их связями
/// </summary>
public class GetPatientsWithDependenciesHandler
{
    private readonly IPatientRepository _patientRepository;

    /// <summary>
    /// <inheritdoc cref="GetPatientsWithDependenciesHandler"/>
    /// </summary>
    public GetPatientsWithDependenciesHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    /// <summary>
    /// Обработать получение пациентов с их связями
    /// </summary>
    public async Task<IReadOnlyCollection<PatientWithDependenciesDto>> HandleAsync(EntityWithDependenciesRequest request)
    {
        var patients = await _patientRepository.GetAllPatientsWithDependenciesAsync(request);

        return patients.Select(patient => new PatientWithDependenciesDto
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthday = patient.Birthday,
                Sex = patient.Sex,
                AreaNumber = new AreaDto
                {
                    Number = patient.AreaNumber.Number
                }
            })
            .ToList();
    }
}