using HealthSync.Domain.Entities;

namespace HealthSync.Tests.Templates;

public static class DoctorsTests
{
    public static List<Doctors> CreateDoctors()
    {
        return new List<Doctors>()
        {
            new Doctors()
            {
                Id = Guid.NewGuid(),
                Name = "Doctor 1 Test",
                Specialization = "Specialization 1 Test",
                PhoneNumber = "123456789",
                Email = "doctor1test@email.com",
                LicenseNumber = "1234567890"
            },
            new Doctors()
            {
                Id = Guid.NewGuid(),
                Name = "Doctor 2 Test",
                Specialization = "Specialization 2 Test",
                PhoneNumber = "098765432",
                Email = "doctor2test@email.com",
                LicenseNumber = "0987654321"
            }
        };
    }

    public static Doctors UpdateDoctor(Guid id)
    {
        return new Doctors()
        {
            Id = id,
            Name = "Doctor Updated",
            Specialization = "Specialization Updated",
            PhoneNumber = "987654321",
            Email = "doctorupdated@email.com",
            LicenseNumber = "657890765"
        };
    }
}
