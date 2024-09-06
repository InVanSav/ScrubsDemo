using ScrubsDemo.Application.IRepository;

namespace ScrubsDemo.Application.UseCases.Doctor;

/// <summary>
/// Обработчик удаления врача
/// </summary>
public class DeleteDoctorHandler
{
    private readonly IDoctorRepository _doctorRepository;

    /// <summary>
    /// <inheritdoc cref="DeleteDoctorHandler"/>
    /// </summary>
    public DeleteDoctorHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    /// <summary>
    /// Выполнить удаление врача
    /// </summary>
    public Task HandleAsync(string fullName)
        => _doctorRepository.DeleteDoctorAsync(fullName);
}