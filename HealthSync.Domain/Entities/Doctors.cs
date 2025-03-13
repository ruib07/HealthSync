namespace HealthSync.Domain.Entities;

public class Doctors
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
}
