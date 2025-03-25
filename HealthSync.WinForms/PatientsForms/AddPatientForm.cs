using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.PatientsForms;

public partial class AddPatientForm : Form
{
    private readonly PatientsService _patientsService;

    public AddPatientForm(PatientsService patientsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;
        _patientsService = patientsService;
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, CreatePatientTitle);
        UIHelper.CenterCreateButton(this, AddPatientButton);
    }


    private async void AddPatientButton_Click(object sender, EventArgs e)
    {
        try
        {
            var newPatient = new Patients()
            {
                Name = PatientName.Text,
                DateOfBirth = DateOnly.FromDateTime(PatientDateOfBirth.Value),
                PhoneNumber = PatientPhoneNumber.Text,
                Email = PatientEmail.Text,
                Address = PatientAddress.Text
            };

            var createdPatient = await _patientsService.CreatePatient(newPatient);

            MessageBox.Show($"Patient {createdPatient.Name} created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
