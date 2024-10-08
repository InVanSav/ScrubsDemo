using Microsoft.AspNetCore.Mvc;
using ScrubsDemo.Application.Dto.DoctorDto;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Application.UseCases.Doctor;

namespace ScrubsDemo.Controllers;

/// <summary>
/// Коntроллер для работы с данными о врачах
/// </summary>
[ApiController]
[Route("api/doctor")]
public class DoctorController : ControllerBase
{
    private readonly CreateDoctorHandler _createDoctorHandler;
    private readonly UpdateDoctorHandler _updateDoctorHandler;
    private readonly DeleteDoctorHandler _deleteDoctorHandler;
    private readonly GetDoctorByFullNameHandler _getDoctorByFullNameHandler;
    private readonly GetDoctorsWithDependenciesHandler _getDoctorsWithDependenciesHandler;

    /// <summary>
    /// <inheritdoc cref="DoctorController"/>
    /// </summary>
    public DoctorController(
        CreateDoctorHandler createDoctorHandler,
        UpdateDoctorHandler updateDoctorHandler,
        DeleteDoctorHandler deleteDoctorHandler,
        GetDoctorByFullNameHandler getDoctorByFullNameHandler,
        GetDoctorsWithDependenciesHandler getDoctorsWithDependenciesHandler)
    {
        _createDoctorHandler = createDoctorHandler;
        _updateDoctorHandler = updateDoctorHandler;
        _deleteDoctorHandler = deleteDoctorHandler;
        _getDoctorByFullNameHandler = getDoctorByFullNameHandler;
        _getDoctorsWithDependenciesHandler = getDoctorsWithDependenciesHandler;
    }

    /// <summary>
    /// Создание врача
    /// </summary>
    [HttpPost("create")]
    public Task CreateDoctorAsync(DoctorWithoutDependenciesDto doctorWithoutDependencies)
        => _createDoctorHandler.HandleAsync(doctorWithoutDependencies);

    /// <summary>
    /// Обновление врача
    /// </summary>
    [HttpPut("update")]
    public Task UpdateDoctorAsync(DoctorWithoutDependenciesDto doctorWithoutDependencies)
        => _updateDoctorHandler.HandleAsync(doctorWithoutDependencies);

    /// <summary>
    /// Удаление врача
    /// </summary>
    [HttpDelete("delete")]
    public Task DeleteDoctorAsync(string fullName)
        => _deleteDoctorHandler.HandleAsync(fullName);

    /// <summary>
    /// Получение врача по его ФИО
    /// </summary>
    [HttpPost("getByFullName")]
    public Task<DoctorWithoutDependenciesDto> GetDoctorByFullNameAsync([FromQuery] string fullName)
        => _getDoctorByFullNameHandler.HandleAsync(fullName);

    /// <summary>
    /// Получение списка врачей с их связями
    /// </summary>
    [HttpPost("getWithDependencies")]
    public Task<IReadOnlyCollection<DoctorWithDependenciesDto>> GetDoctorsWithDependenciesAsync([FromBody] EntityWithDependenciesRequest request)
        => _getDoctorsWithDependenciesHandler.HandleAsync(request);
}