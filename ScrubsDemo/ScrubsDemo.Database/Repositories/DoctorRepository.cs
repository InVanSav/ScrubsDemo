using System.Data;
using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Application.IRepository.Requests;
using ScrubsDemo.Database.MsSql;
using ScrubsDemo.Domain.Entities;
using ScrubsDemo.Domain.Entities.Doctor;

namespace ScrubsDemo.Database.Repositories;

/// <inheritdoc />
public class DoctorRepository : IDoctorRepository
{
    /// <summary>
    /// Обработчик запросов к базе данных
    /// </summary>
    private readonly MsSqlHandler _msSqlHandler;

    /// <summary>
    /// <inheritdoc cref="DoctorRepository"/>
    /// </summary>
    public DoctorRepository(MsSqlHandler msSqlHandler)
    {
        _msSqlHandler = msSqlHandler;
    }

    // <inheritdoc />
    public Task CreateDoctorAsync(DoctorWithoutDependencies doctorWithoutDependencies)
        => _msSqlHandler.ExecuteAsync("Doctor.CreateDoctor",
                new KeyValuePair<string, object>("fullName", doctorWithoutDependencies.FullName),
                new KeyValuePair<string, object>("specialization", doctorWithoutDependencies.Specialization),
                new KeyValuePair<string, object>("area", doctorWithoutDependencies.Area),
                new KeyValuePair<string, object>("office", doctorWithoutDependencies.Office));

    // <inheritdoc />
    public Task UpdateDoctorAsync(DoctorWithoutDependencies doctorWithoutDependencies)
        => _msSqlHandler.ExecuteAsync("Doctor.UpdateDoctor",
            new KeyValuePair<string, object>("fullName", doctorWithoutDependencies.FullName),
            new KeyValuePair<string, object>("specialization", doctorWithoutDependencies.Specialization),
            new KeyValuePair<string, object>("area", doctorWithoutDependencies.Area),
            new KeyValuePair<string, object>("office", doctorWithoutDependencies.Office));

    // <inheritdoc />
    public Task DeleteDoctorAsync(string fullName)
        => _msSqlHandler.ExecuteAsync("Doctor.DeleteDoctor",
            new KeyValuePair<string, object>("fullName", fullName));

    // <inheritdoc />
    public Task<DoctorWithoutDependencies> GetDoctorByFullNameAsync(string fullName)
        => _msSqlHandler.ReadAsync("Doctor.GetDoctorByFullName",
            dataReader => new DoctorWithoutDependencies
            {
                FullName = dataReader.GetString("fullName"),
                Specialization = dataReader.GetInt32("specialization"),
                Area = dataReader.GetInt32("area"),
                Office = dataReader.GetInt32("office")
            },
            new KeyValuePair<string, object>("fullName", fullName));

    // <inheritdoc />
    public Task<IReadOnlyCollection<DoctorWithDependencies>> GetAllDoctorsWithDependenciesAsync(EntityWithDependenciesRequest request)
        => _msSqlHandler.ReadManyByParametersAsync<DoctorWithDependencies>("Doctor.SelectDoctorOrderedRange",
            dataReader => new DoctorWithDependencies
            {
                FullName = dataReader.GetString("fullName"),
                Specialization = new Specialization
                {
                    Id = dataReader.GetInt32("specializationId"),
                    Name = dataReader.GetString("specialization")
                },
                Area = new Area
                {
                    Number = dataReader.GetInt32("area")
                },
                Office = new Office
                {
                    Number = dataReader.GetInt32("office")
                }
            },
            new KeyValuePair<string, object>("offset", request.Offset),
            new KeyValuePair<string, object>("limit", request.Limit),
            new KeyValuePair<string, object>("column", request.SortingColumn));
}