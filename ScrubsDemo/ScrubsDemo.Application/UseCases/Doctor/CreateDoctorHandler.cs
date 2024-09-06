using ScrubsDemo.Application.Dto.DoctorDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Application.UseCases.Doctor;

/// <summary>
/// Обработчик создания врача
/// </summary>
public class CreateDoctorHandler
{
    private readonly IDoctorRepository _doctorRepository;

    /// <summary>
    /// <inheritdoc cref="CreateDoctorHandler"/>
    /// </summary>
    public CreateDoctorHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    /// <summary>
    /// Выполнить создание врача
    /// </summary>
    public async Task HandleAsync(DoctorWithoutDependenciesDto doctorWithoutDependencies)
    {
        var doctor = new DoctorWithoutDependencies
        {
            FullName = doctorWithoutDependencies.FullName,
            Office = doctorWithoutDependencies.Office,
            Specialization = doctorWithoutDependencies.Specialization,
            Area = doctorWithoutDependencies.Area
        };

        await _doctorRepository.CreateDoctorAsync(doctor);        
    }
}