using HealthSync.WinForms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealthSync.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var serviceProvider = new ServiceCollection().AddSingleton<HttpClient>(sp =>
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri("http://localhost:3005")
                };
                return httpClient;
            })
            .AddSingleton<PatientsService>()
            .AddSingleton<DoctorsService>()
            .AddSingleton<AppointmentsService>()
            .AddSingleton<MedicalRecordsService>()
            .AddSingleton<HealthSyncForm>()
            .BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var healthSyncForm = serviceProvider.GetRequiredService<HealthSyncForm>();
            Application.Run(healthSyncForm);
        }
    }
}