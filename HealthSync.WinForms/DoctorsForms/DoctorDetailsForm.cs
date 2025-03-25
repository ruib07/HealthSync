using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.DoctorsForms;

public partial class DoctorDetailsForm : Form
{
    private readonly Doctors _doctor;
    private readonly DoctorsService _doctorsService;

    public DoctorDetailsForm(Doctors doctor, DoctorsService doctorsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _doctor = doctor;
        _doctorsService = doctorsService;
        LoadDoctorDetails();
    }

    private void DoctorDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label>() { DoctorNameLabel, DoctorEmailLabel, DoctorSpecializationLabel, DoctorPhoneNumberLabel, DoctorLicenseNumberLabel },
           new List<Control>() { DoctorNameValue, DoctorEmailValue, DoctorSpecializationValue, DoctorPhoneNumberValue, DoctorLicenseNumberValue },
           startY: 200,
           spacing: 60
        );

        ToggleEditMode(false);
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, DoctorDetailsTitle);
    }

    private void LoadDoctorDetails()
    {
        DoctorNameValue.Text = _doctor.Name;
        DoctorEmailValue.Text = _doctor.Email;
        DoctorSpecializationValue.Text = _doctor.Specialization;
        DoctorPhoneNumberValue.Text = _doctor.PhoneNumber;
        DoctorLicenseNumberValue.Text = _doctor.LicenseNumber;
    }

    private void EditDoctorButton_Click(object sender, EventArgs e)
    {
        ToggleEditMode(true);
    }

    private async void SaveDoctorButton_Click(object sender, EventArgs e)
    {
        try
        {
            var updatedDoctor = new Doctors()
            {
                Id = _doctor.Id,
                Name = DoctorNameValue.Text,
                Email = DoctorEmailValue.Text,
                Specialization = DoctorSpecializationValue.Text,
                PhoneNumber = DoctorPhoneNumberValue.Text,
                LicenseNumber = DoctorLicenseNumberValue.Text
            };

            await _doctorsService.EditDoctor(_doctor.Id, updatedDoctor);

            _doctor.Name = updatedDoctor.Name;
            _doctor.Email = updatedDoctor.Email;
            _doctor.Specialization = updatedDoctor.Specialization;
            _doctor.PhoneNumber = updatedDoctor.PhoneNumber;
            _doctor.LicenseNumber = updatedDoctor.LicenseNumber;

            MessageBox.Show("Doctor details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            DoctorNameValue, DoctorEmailValue, DoctorSpecializationValue, DoctorPhoneNumberValue, DoctorLicenseNumberValue 
        }, EditDoctorButton, SaveDoctorButton);
    }
}
