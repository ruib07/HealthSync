using HealthSync.Domain.Entities;

namespace HealthSync.Tests.Templates;

public static class PatientsTests
{
    public static List<Patients> CreatePatients()
    {
        return new List<Patients>()
        {
            new Patients()
            {
                Id = Guid.NewGuid(),
                Name = "Patient 1 Test",
                DateOfBirth = new DateOnly(1990, 1, 1),
                PhoneNumber = "123456789",
                Email = "patient1test@email.com",
                Address = "Patient 1 Address Test"
            },
            new Patients()
            {
                Id = Guid.NewGuid(),
                Name = "Patient 2 Test",
                DateOfBirth = new DateOnly(1995, 2, 14),
                PhoneNumber = "098765432",
                Email = "patient2test@email.com",
                Address = "Patient 2 Address Test"
            }
        };
    }

    public static Patients UpdatePatient(Guid id)
    {
        return new Patients()
        {
            Id = id,
            Name = "Patient Updated",
            DateOfBirth = new DateOnly(2002, 10, 23),
            PhoneNumber = "987654321",
            Email = "patientupdated@email.com",
            Address = "Patient Address Updated"
        };
    }
}
