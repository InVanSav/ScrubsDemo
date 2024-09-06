using System.Data;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Database.MsSql;
using ScrubsDemo.Domain.Entities;
using ScrubsDemo.Domain.Entities.Patient;

namespace ScrubsDemo.Database.Repositories;

/// <summary>
/// Репозиторий для работы с данными о пациентах
/// </summary>
public class PatientRepository : IPatientRepository
{
    /// <summary>
    /// Обработчик запросов к базе данных
    /// </summary>
    private readonly MsSqlHandler _msSqlHandler;

    /// <summary>
    /// <inheritdoc cref="PatientRepository"/>
    /// </summary>
    public PatientRepository(MsSqlHandler msSqlHandler)
    {
        _msSqlHandler = msSqlHandler;
    }

    // <inheritdoc />
    public Task CreatePatientAsync(PatientWithoutDependencies patientWithoutDependencies)
        => _msSqlHandler.ExecuteAsync("Patient.CreatePatient",
            new KeyValuePair<string, object>("name", patientWithoutDependencies.Name),
            new KeyValuePair<string, object>("surname", patientWithoutDependencies.Surname),
            new KeyValuePair<string, object>("patronymic", patientWithoutDependencies.Patronymic ?? string.Empty),
            new KeyValuePair<string, object>("address", patientWithoutDependencies.Address),
            new KeyValuePair<string, object>("birthday", patientWithoutDependencies.Birthday),
            new KeyValuePair<string, object>("sex", (int)patientWithoutDependencies.Sex),
            new KeyValuePair<string, object>("areaNumber", patientWithoutDependencies.AreaNumber));

    // <inheritdoc />
    public Task UpdatePatientAsync(PatientWithoutDependencies patientWithoutDependencies)
        => _msSqlHandler.ExecuteAsync("Patient.UpdatePatient",
            new KeyValuePair<string, object>("name", patientWithoutDependencies.Name),
            new KeyValuePair<string, object>("surname", patientWithoutDependencies.Surname),
            new KeyValuePair<string, object>("patronymic", patientWithoutDependencies.Patronymic ?? string.Empty),
            new KeyValuePair<string, object>("address", patientWithoutDependencies.Address),
            new KeyValuePair<string, object>("birthday", patientWithoutDependencies.Birthday),
            new KeyValuePair<string, object>("sex", (int)patientWithoutDependencies.Sex),
            new KeyValuePair<string, object>("areaNumber", patientWithoutDependencies.AreaNumber));

    // <inheritdoc />
    public Task DeletePatientAsync(string name, string surname, string? patronymic)
        => _msSqlHandler.ExecuteAsync("Patient.DeletePatient",
            new KeyValuePair<string, object>("name", name),
            new KeyValuePair<string, object>("surname", surname),
            new KeyValuePair<string, object>("patronymic", patronymic ?? string.Empty));

    // <inheritdoc />
    public Task<PatientWithoutDependencies> GetPatientByFullNameAsync(string name, string surname, string? patronymic)
        => _msSqlHandler.ReadAsync("Patient.GetPatientByFullName",
            dataReader => new PatientWithoutDependencies
            {
                Name = dataReader.GetString("name"),
                Surname = dataReader.GetString("surname"),
                Patronymic = dataReader.GetString("patronymic"),
                Address = dataReader.GetString("address"),
                Birthday = dataReader.GetDateTime("birthday"),
                Sex = (Sex)dataReader.GetInt32("sex"),
                AreaNumber = dataReader.GetInt32("areaNumber")
            },
            new KeyValuePair<string, object>("name", name),
            new KeyValuePair<string, object>("surname", surname),
            new KeyValuePair<string, object>("patronymic", patronymic ?? string.Empty));

    // <inheritdoc />
    public Task<IReadOnlyCollection<PatientWithDependencies>> GetAllPatientsWithDependenciesAsync(EntityWithDependenciesRequest request)
        => _msSqlHandler.ReadManyByParametersAsync<PatientWithDependencies>("Patient.SelectPatientOrderedRange",
            dataReader => new PatientWithDependencies
            {
                Name = dataReader.GetString("name"),
                Surname = dataReader.GetString("surname"),
                Patronymic = dataReader.GetString("patronymic"),
                Address = dataReader.GetString("address"),
                Birthday = dataReader.GetDateTime("birthday"),
                Sex = (Sex)dataReader.GetInt32("sex"),
                AreaNumber = new Area
                {
                    Number = dataReader.GetInt32("areaNumber")
                }
            },
            new KeyValuePair<string, object>("offset", request.Offset),
            new KeyValuePair<string, object>("limit", request.Limit),
            new KeyValuePair<string, object>("column", request.Column));
}