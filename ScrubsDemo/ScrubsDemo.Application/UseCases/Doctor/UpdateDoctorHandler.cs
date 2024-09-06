using ScrubsDemo.Application.Dto.DoctorDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Application.UseCases.Doctor;

/// <summary>
/// Обработчик обновления врача
/// </summary>
public class UpdateDoctorHandler
{
    private readonly IDoctorRepository _doctorRepository;

    /// <summary>
    /// <inheritdoc cref="UpdateDoctorHandler"/>
    /// </summary>
    public UpdateDoctorHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    /// <summary>
    /// Выполнить обновление врача
    /// </summary>
    public async Task Handle(DoctorWithoutDependenciesDto doctorWithoutDependencies)
    {
        var doctor = new DoctorWithoutDependencies
        {
            FullName = doctorWithoutDependencies.FullName,
            Office = doctorWithoutDependencies.Office,
            Specialization = doctorWithoutDependencies.Specialization,
            Area = doctorWithoutDependencies.Area
        };

        await _doctorRepository.UpdateDoctorAsync(doctor);        
    }
}