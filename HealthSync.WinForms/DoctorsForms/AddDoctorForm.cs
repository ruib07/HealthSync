using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.DoctorsForms;

public partial class AddDoctorForm : Form
{
    private readonly DoctorsService _doctorsService;

    public AddDoctorForm(DoctorsService doctorsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;
        _doctorsService = doctorsService;
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, CreateDoctorTitle);
        UIHelper.CenterCreateButton(this, AddDoctorButton);
    }

    private async void AddDoctorButton_Click(object sender, EventArgs e)
    {
        try
        {
            var newDoctor = new Doctors()
            {
                Name = DoctorName.Text,
                Specialization = DoctorSpecialization.Text,
                PhoneNumber = DoctorPhoneNumber.Text,
                Email = DoctorEmail.Text,
                LicenseNumber = DoctorLicenseNumber.Text
            };

            var createdPatient = await _doctorsService.CreateDoctor(newDoctor);

            MessageBox.Show($"Doctor {createdPatient.Name} created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating doctor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
