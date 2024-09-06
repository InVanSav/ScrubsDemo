using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Application.UseCases.Doctor;
using ScrubsDemo.Application.UseCases.Patient;
using ScrubsDemo.Database.MsSql;
using ScrubsDemo.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<MsSqlConnection>()
    .Bind(builder.Configuration.GetSection("Config:MsSqlConnection"));

builder.Services.AddSingleton<MsSqlHandler>();

builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

builder.Services.AddSingleton<CreateDoctorHandler>();
builder.Services.AddSingleton<UpdateDoctorHandler>();
builder.Services.AddSingleton<DeleteDoctorHandler>();
builder.Services.AddSingleton<GetDoctorByFullNameHandler>();
builder.Services.AddSingleton<GetDoctorsWithDependenciesHandler>();

builder.Services.AddSingleton<CreatePatientHandler>();
builder.Services.AddSingleton<UpdatePatientHandler>();
builder.Services.AddSingleton<DeletePatientHandler>();
builder.Services.AddSingleton<GetPatientByFullNameHandler>();
builder.Services.AddSingleton<GetPatientsWithDependenciesHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();