using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Application.IRepository;

/// <summary>
/// Репозиторий для работы с данными о пациентах
/// </summary>
public interface IPatientRepository
{
    /// <summary>
    /// Создание пациента
    /// </summary>
    public Task CreatePatientAsync(PatientWithoutDependencies patientWithoutDependencies);

    /// <summary>
    /// Обновление пациента
    /// </summary>
    public Task UpdatePatientAsync(PatientWithoutDependencies patientWithoutDependencies);

    /// <summary>
    /// Удаление пациента
    /// </summary>
    public Task DeletePatientAsync(string name, string surname, string? patronymic);

    /// <summary>
    /// Получение пациента по его ФИО
    /// </summary>
    public Task<PatientWithoutDependencies> GetPatientByFullNameAsync(string name, string surname, string? patronymic);

    /// <summary>
    /// Получение списка пациентов с их связями
    /// </summary>
    public Task<IReadOnlyCollection<PatientWithDependencies>> GetAllPatientsWithDependenciesAsync(EntityWithDependenciesRequest request);
}