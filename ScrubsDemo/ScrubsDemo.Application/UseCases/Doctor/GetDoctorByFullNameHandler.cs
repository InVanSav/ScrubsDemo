using ScrubsDemo.Application.IRepository;

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
    public Task Handle(string fullName)
        => _doctorRepository.GetDoctorByFullNameAsync(fullName);
}