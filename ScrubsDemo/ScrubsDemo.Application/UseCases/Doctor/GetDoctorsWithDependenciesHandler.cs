using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Application.UseCases.Doctor;

/// <summary>
/// Обработчик получения списка врачей с их связями
/// </summary>
public class GetDoctorsWithDependenciesHandler
{
    private readonly IDoctorRepository _doctorRepository;

    /// <summary>
    /// <inheritdoc cref="GetDoctorsWithDependenciesHandler"/>
    /// </summary>
    public GetDoctorsWithDependenciesHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    /// <summary>
    /// Обработать получение списка врачей с их связями
    /// </summary>
    public Task<IReadOnlyCollection<DoctorWithDependencies>> Handle(EntityWithDependenciesRequest request)
        => _doctorRepository.GetAllDoctorsWithDependenciesAsync(request);
}