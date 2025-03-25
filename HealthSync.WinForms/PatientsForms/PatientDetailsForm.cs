using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.PatientsForms;

public partial class PatientDetailsForm : Form
{
    private readonly Patients _patient;
    private readonly PatientsService _patientsService;

    public PatientDetailsForm(Patients patient, PatientsService patientsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _patient = patient;
        _patientsService = patientsService;
        LoadPatientDetails();
    }

    private void PatientDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
            new List<Label> { PatientNameLabel, PatientEmailLabel, PatientDateOfBirthLabel, PatientPhoneNumberLabel, PatientAddressLabel },
            new List<Control> { PatientNameValue, PatientEmailValue, PatientDateOfBirthValue, PatientPhoneNumberValue, PatientAddressValue },
            startY: 200,
            spacing: 60
        );

        ToggleEditMode(false);
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, PatientDetailsTitle);
    }

    private void LoadPatientDetails()
    {
        PatientNameValue.Text = _patient.Name;
        PatientEmailValue.Text = _patient.Email;
        PatientDateOfBirthValue.Text = _patient.DateOfBirth.ToString();
        PatientPhoneNumberValue.Text = _patient.PhoneNumber;
        PatientAddressValue.Text = _patient.Address;
    }

    private void EditPatientButton_Click(object sender, EventArgs e)
    {
        ToggleEditMode(true);
    }

    private async void SavePatientButton_Click(object sender, EventArgs e)
    {
        try
        {
            var updatedPatient = new Patients()
            {
                Id = _patient.Id,
                Name = PatientNameValue.Text,
                Email = PatientEmailValue.Text,
                DateOfBirth = DateOnly.Parse(PatientDateOfBirthValue.Text),
                PhoneNumber = PatientPhoneNumberValue.Text,
                Address = PatientAddressValue.Text
            };

            await _patientsService.EditPatient(_patient.Id, updatedPatient);

            _patient.Name = updatedPatient.Name;
            _patient.Email = updatedPatient.Email;
            _patient.DateOfBirth = updatedPatient.DateOfBirth;
            _patient.PhoneNumber = updatedPatient.PhoneNumber;
            _patient.Address = updatedPatient.Address;

            MessageBox.Show("Patient details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ToggleEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ToggleEditMode(bool enable)
    {
        UIHelper.ToggleEditMode(this, enable, new List<Control>()
        { 
            PatientNameValue, PatientEmailValue, PatientDateOfBirthValue, PatientPhoneNumberValue, PatientAddressValue 
        }, EditPatientButton, SavePatientButton);
    }
}
