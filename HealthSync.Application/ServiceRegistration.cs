using HealthSync.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace HealthSync.Application;

public static class ServiceRegistration
{
    public static void AddCustomServiceDependencyRegister(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceAssemblies = new[]
        {
            typeof(DoctorsService),
            typeof(PatientsService),
            typeof(AppointmentsService),
            typeof(MedicalRecordsService)
        };

        foreach (var serviceType in serviceAssemblies)
        {
            RegisterServicesFromAssembly(services, serviceType.Assembly);
        }
    }

    #region Private Methods

    private static void RegisterServicesFromAssembly(IServiceCollection services, Assembly assembly)
    {
        services.Scan(scan => scan.FromAssemblies(assembly)
                .AddClasses(classes => classes
                .Where(p => p.Name != null && p.Name.EndsWith("Service") && !p.IsInterface))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }

    #endregion
}
