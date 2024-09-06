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
    public Task<IReadOnlyCollection<PatientWithDependencies>> Handle(EntityWithDependenciesRequest request)
        => _patientRepository.GetAllPatientsWithDependenciesAsync(request);
}