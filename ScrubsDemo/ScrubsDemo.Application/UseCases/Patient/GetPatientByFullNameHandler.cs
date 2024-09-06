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
    public Task<PatientWithoutDependencies> Handle(string name, string surname, string patronymic)
        => _patientRepository.GetPatientByFullNameAsync(name, surname, patronymic);
}