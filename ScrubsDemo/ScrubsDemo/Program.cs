using ScrubsDemo.Application.IRepository;
using ScrubsDemo.Database.MsSql;
using ScrubsDemo.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<MsSqlConnection>()
    .Bind(builder.Configuration.GetSection("Config:MsSqlConnection"));

builder.Services.AddSingleton<MsSqlHandler>();

builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();