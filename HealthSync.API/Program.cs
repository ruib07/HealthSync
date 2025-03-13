using HealthSync.API.Configurations;
using HealthSync.API.Middlewares;
using HealthSync.Application;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddCustomApiSecurity(configuration);
builder.Services.AddCustomServiceDependencyRegister(configuration);
builder.Services.AddCustomDatabaseConfiguration(configuration);

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();

builder.Services.AddScoped<DoctorsService>();
builder.Services.AddScoped<PatientsService>();
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<MedicalRecordsService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();
