using ScrubsDemo.Application.IRepository;

namespace ScrubsDemo.Application.UseCases.Patient;

/// <summary>
/// Обработчик удаления пациента
/// </summary>
public class DeletePatientHandler
{
    private readonly IPatientRepository _patientRepository;

    /// <summary>
    /// <inheritdoc cref="DeletePatientHandler"/>
    /// </summary>
    public DeletePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    /// <summary>
    /// Обработать удаление пациента
    /// </summary>
    public Task Handle(string name, string surname, string patronymic)
        => _patientRepository.DeletePatientAsync(name, surname, patronymic);
}