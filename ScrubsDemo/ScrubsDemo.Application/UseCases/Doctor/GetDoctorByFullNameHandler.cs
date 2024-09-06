using ScrubsDemo.Application.Dto.DoctorDto;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Application.UseCases.Doctor;

/// <summary>
/// Обработчик получения врача по ФИО
/// </summary>
public class GetDoctorByFullNameHandler
{
    private readonly IDoctorRepository _doctorRepository;

    /// <summary>
    /// <inheritdoc cref="GetDoctorByFullNameHandler"/>
    /// </summary>
    public GetDoctorByFullNameHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    /// <summary>
    /// Выполнить получение врача
    /// </summary>
    public async Task<DoctorWithoutDependenciesDto> HandleAsync(string fullName)
    {
        var doctor = await _doctorRepository.GetDoctorByFullNameAsync(fullName);

        return new DoctorWithoutDependenciesDto
        {
            FullName = doctor.FullName,
            Specialization = doctor.Specialization,
            Area = doctor.Area,
            Office = doctor.Office
        };
    }
}