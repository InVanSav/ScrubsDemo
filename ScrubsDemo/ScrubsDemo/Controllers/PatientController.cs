using Microsoft.AspNetCore.Mvc;
using ScrubsDemo.Application.Dto.PatientDto;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Application.UseCases.Patient;

namespace ScrubsDemo.Controllers;

/// <summary>
/// Контроллер для работы с данными о пациентах
/// </summary>
[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase
{
    private readonly CreatePatientHandler _createPatientHandler;
    private readonly UpdatePatientHandler _updatePatientHandler;
    private readonly DeletePatientHandler _deletePatientHandler;
    private readonly GetPatientByFullNameHandler _getPatientByFullNameHandler;
    private readonly GetPatientsWithDependenciesHandler _getPatientsWithDependenciesHandler;

    /// <summary>
    /// <inheritdoc cref="PatientController"/>
    /// </summary>
    public PatientController(
        GetPatientsWithDependenciesHandler getPatientsWithDependenciesHandler,
        UpdatePatientHandler updatePatientHandler,
        CreatePatientHandler createPatientHandler,
        GetPatientByFullNameHandler getPatientByFullNameHandler,
        DeletePatientHandler deletePatientHandler)
    {
        _getPatientsWithDependenciesHandler = getPatientsWithDependenciesHandler;
        _updatePatientHandler = updatePatientHandler;
        _createPatientHandler = createPatientHandler;
        _getPatientByFullNameHandler = getPatientByFullNameHandler;
        _deletePatientHandler = deletePatientHandler;
    }

    /// <summary>
    /// Создание пациента
    /// </summary>
    public Task CreatePatientAsync(PatientWithoutDependenciesDto patientWithoutDependencies)
        => _createPatientHandler.HandleAsync(patientWithoutDependencies);

    /// <summary>
    /// Обновление пациента
    /// </summary>
    public Task UpdatePatientAsync(PatientWithoutDependenciesDto patientWithoutDependencies)
        => _updatePatientHandler.HandleAsync(patientWithoutDependencies);

    /// <summary>
    /// Удаление пациента
    /// </summary>
    public Task DeletePatientAsync(string name, string surname, string? patronymic)
        => _deletePatientHandler.HandleAsync(name, surname, patronymic);

    /// <summary>
    /// Получение пациента по его ФИО
    /// </summary>
    public Task<PatientWithoutDependenciesDto> GetPatientByFullNameAsync(string name, string surname, string? patronymic)
        => _getPatientByFullNameHandler.HandleAsync(name, surname, patronymic);

    /// <summary>
    /// Получение списка пациентов с их связями
    /// </summary>
    public Task<IReadOnlyCollection<PatientWithDependenciesDto>> GetAllPatientsWithDependenciesAsync(EntityWithDependenciesRequest request)
        => _getPatientsWithDependenciesHandler.HandleAsync(request);
}