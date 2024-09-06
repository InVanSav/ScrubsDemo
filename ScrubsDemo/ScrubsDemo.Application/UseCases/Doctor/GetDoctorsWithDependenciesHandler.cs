using ScrubsDemo.Application.Dto;
using ScrubsDemo.Application.Dto.DoctorDto;
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
    public async Task<IReadOnlyCollection<DoctorWithDependenciesDto>> HandleAsync(EntityWithDependenciesRequest request)
    {
        var doctors = await _doctorRepository.GetAllDoctorsWithDependenciesAsync(request);

        return doctors.Select(doctor => new DoctorWithDependenciesDto
        {
            FullName = doctor.FullName,
            Specialization = new SpecializationDto
            {
                Id = doctor.Specialization.Id,
                Name = doctor.Specialization.Name
            },
            Area = new AreaDto
            {
                Number = doctor.Area.Number
            },
            Office = new OfficeDto
            {
                Number = doctor.Office.Number
            }
        })
            .ToList();
    }
}