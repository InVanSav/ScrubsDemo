using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Application.IRepository;

/// <summary>
/// Репозиторий для работы с данными о врачах
/// </summary>
public interface IDoctorRepository
{
    /// <summary>
    /// Создание врача
    /// </summary>
    public Task CreateDoctorAsync(DoctorWithoutDependencies doctorWithoutDependencies);

    /// <summary>
    /// Обновление врача
    /// </summary>
    public Task UpdateDoctorAsync(DoctorWithoutDependencies doctorWithoutDependencies);

    /// <summary>
    /// Получение списка врачей с их связями
    /// </summary>
    public Task<IReadOnlyCollection<DoctorWithDependencies>> GetAllDoctorsWithDependenciesAsync(EntityWithDependenciesRequest request);

    /// <summary>
    /// Удаление врача
    /// </summary>
    public Task DeleteDoctorAsync(string fullName);

    /// <summary>
    /// Получение врача по его ФИО
    /// </summary>
    public Task<DoctorWithoutDependencies> GetDoctorByFullNameAsync(string fullName);
}